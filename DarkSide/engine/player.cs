using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using FarseerGames.FarseerPhysics.Collisions;

namespace DarkSide
{
 public class PLAYER
 {
  public enum STATE
  {
   run,
   walk,
   stand,
   inAir,
   holdOn,
  }
  public STATE state = STATE.inAir;

  private DEVICE_PACK p;
  private OBJECT obj = new OBJECT();

  float dx, dy;
  Vector2 holdPos = Vector2.Zero;
  Vector2 holdDir = Vector2.Zero;
  Vector2 uvpos = new Vector2(0, 0);
  Vector2 uvmul = new Vector2(1.0f / 6.0f, 0.5f);
  bool jump = false;
  bool starthand = false;
  public bool onGround = false;
  ContactList contDraw = new ContactList(1);
  float gt = 0;

  public Vector2 Position
  {
   get
   {
    return obj.Position;
   }
   set
   {
    obj.Position = value;
   }
  }
  private bool OnCollision(Geom geom1, Geom geom2, ContactList contactList)
  {
   if (state == STATE.holdOn) return true;
   contDraw = contactList;
   bool ongr = false;

   #region HAND
   foreach (Contact cont in contactList)
   {
    if (cont.Normal.X == -1 || cont.Normal.X == 1)
    {
     state = STATE.inAir;

     Vector2 upper = contactList[0].Position;
     foreach (Contact c in contactList)
      if (c.Position.Y > upper.Y) upper = c.Position;

     foreach (Vector2 v in geom2.WorldVertices)
      if ((v - upper).Length() < 0.01f)
      {
       bool yes = false;
       foreach (Contact contTry in contactList)
        if ((contTry.Position - v).Length() > 1.4f)
        {
         holdPos = v; holdDir = contTry.Normal;
         yes = true;
         starthand = false;
        }

       if (yes)
       {
        uvmul.X = -Math.Sign(holdDir.X);
        uvpos = new Vector2(0, 0.5f);
        obj.objDesc[0].body.Enabled = false;
        state = STATE.holdOn; return true;
       }
      }

     ongr = false;
    }
    if (cont.Normal.Y == 1 && ongr == false) { ongr = true; break; }
    //if (ongr == false) { ongr = true; break; }
   }
   #endregion

   if (ongr)
   {
    if (!jump)
    {
     if (obj.objDesc[0].body.LinearVelocity.Length() < 0.01f) state = STATE.stand;
     else state = STATE.run;
     obj.objDesc[0].body.LinearVelocity.Y = 0;
    }

    onGround = true;
   }

   return true;
  }
  public bool Init(DEVICE_PACK dp)
  {
   obj.debugVerts = true;
   p = dp;
   if (obj.Init(dp, "player_1", "player", new Vector2(0.5f, 2), OBJTYPE.none)) return true;
   obj.makeBox(0.5f, 2, 65);
   obj.setFriction(1);
   obj.objDesc[0].geom.OnCollision += OnCollision;

   return false;
  }
  public void Update(float dt)
  {
   gt += dt * 5;
   if (gt > 5) gt = 0;
   uvpos.X = ((int)gt) / 6.0f;

   dx = 0; dy = 0;

   #region HOLD_ON
   if (state == STATE.holdOn)
   {
    //upgame
    if (starthand)
    {
     obj.objDesc[0].body.Position += new Vector2(-Math.Sign(holdDir.X) * 0.3f, 1) * 5 * dt;
     if ((obj.objDesc[0].body.Position - holdPos).Length() > 1.5f)
     {
      obj.objDesc[0].body.Enabled = true;
      state = STATE.inAir;
     }
    }
    if (p.input.isKeyJustDown(Keys.Up)) { starthand = true; }
    return;
   }
   #endregion

   #region MOVES
   if (p.input.isKeyDown(Keys.Left)) dx = -1000 * dt;
   if (p.input.isKeyDown(Keys.Right)) dx = 1000 * dt;
   if (p.input.isKeyJustDown(Keys.Up)) dy = 500;
   if (onGround == false) dy = 0;

   if (dx > 0) { uvmul = new Vector2(1.0f / 6.0f, 0.5f); uvpos.Y = 0.5f; obj.mesh.Multiply = new Vector2(Math.Abs(obj.mesh.Multiply.X) * -1, obj.mesh.Multiply.Y); }
   if (dx < 0) { uvmul = new Vector2(1.0f / 6.0f, 0.5f); uvpos.Y = 0.5f; obj.mesh.Multiply = new Vector2(Math.Abs(obj.mesh.Multiply.X) * 1, obj.mesh.Multiply.Y); }
   if (dx == 0) uvpos.Y = 0;

   if (p.input.ScrollWheelValueNow > p.input.ScrollWheelValuePrev) p.camera.Height -= dt * 300;
   if (p.input.ScrollWheelValueNow < p.input.ScrollWheelValuePrev) p.camera.Height += dt * 300;

   if (dx != 0 && state == STATE.stand) state = STATE.run;
   #endregion

   #region CHECK
   if (dy != 0) { jump = true; state = STATE.inAir; }
   obj.objDesc[0].body.ApplyImpulse(new Vector2(dx, dy));
   if (obj.objDesc[0].body.LinearVelocity.X > 5) obj.objDesc[0].body.LinearVelocity.X = 5;
   if (obj.objDesc[0].body.LinearVelocity.X < -5) obj.objDesc[0].body.LinearVelocity.X = -5;
   obj.objDesc[0].body.Rotation = 0;
   obj.objDesc[0].body.AngularVelocity = 0;
   obj.objDesc[0].body.ClearTorque();

   onGround = false;
   #endregion
  }
  public void PostUpdate()
  {
   jump = false;
   obj.Update(0);
  }
  public void Draw(Effect effect)
  {
   obj.mesh.rot = Matrix.CreateRotationZ(0);
   obj.mesh.Position = Position;
   obj.mesh.uv = new Vector4(uvmul.X, uvmul.Y, uvpos.X, uvpos.Y);
   obj.mesh.Draw(effect);
  }
  public void contactDraw()
  {
   if (contDraw.Count == 0) return;
   obj.baseEffect.Projection = p.camera.proj;
   obj.baseEffect.View = p.camera.view;
   obj.baseEffect.World = Matrix.CreateRotationZ(0);
   obj.baseEffect.VertexColorEnabled = true;
   obj.baseEffect.LightingEnabled = false;
   obj.baseEffect.Begin();
   obj.baseEffect.CurrentTechnique.Passes[0].Begin();

   p.gd.VertexDeclaration = new VertexDeclaration(p.gd, VertexPositionColor.VertexElements);

   VertexPositionColor[] temp = new VertexPositionColor[contDraw.Count];
   for (int j = 0; j < contDraw.Count; ++j)
   {
    temp[j].Position = new Vector3(contDraw[j].Position, 0);
    temp[j].Color = Color.Red;
   }
   p.gd.RenderState.PointSize = 4;
   p.gd.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.PointList, temp, 0, contDraw.Count);

   obj.baseEffect.End();
   obj.baseEffect.CurrentTechnique.Passes[0].End();
  }

 }//class
}//namespace

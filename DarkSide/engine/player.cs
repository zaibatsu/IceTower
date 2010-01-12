using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using FarseerGames.FarseerPhysics;
using FarseerGames.FarseerPhysics.Dynamics;
using FarseerGames.FarseerPhysics.Factories;
using FarseerGames.FarseerPhysics.Collisions;

namespace DarkSide
{
 enum PLAYER_STATE
 {
  run,
  walk,
  stand,
  inAir,
  holdOn,
 }

 class PLAYER
 {
  private DEVICE_PACK p;

  public PLAYER_STATE state = PLAYER_STATE.inAir;
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
   if (state == PLAYER_STATE.holdOn) return true;
   contDraw = contactList;
   bool ongr = false;

   #region HAND
   foreach (Contact cont in contactList)
   {
    if (cont.Normal.X == -1 || cont.Normal.X == 1)
    {
     state = PLAYER_STATE.inAir;

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
        obj.body[0].Enabled = false;
        state = PLAYER_STATE.holdOn; return true;
       }
      }

     ongr = false;
    }
    if (cont.Normal.Y == 1 && ongr == false) { ongr = true; break; }
    if (geom2.FrictionCoefficient == 2 && ongr == false) { ongr = true; break; }
   }
   #endregion

   if (ongr)
   {
    if (!jump)
    {
     if (obj.body[0].LinearVelocity.Length() < 0.01f) state = PLAYER_STATE.stand;
     else state = PLAYER_STATE.run;
     obj.body[0].LinearVelocity.Y = 0;
    }

    onGround = true;
   }

   return true;
  }
  public bool Init(DEVICE_PACK dp)
  {
   obj.debugVerts = true;
   p = dp;
   if (obj.Init(dp, "player_1", "player",  new Vector2(0.5f, 2), OBJTYPE.none)) return true;
   obj.MakeBox(0.5f, 2, 65);
   obj.geom[0].FrictionCoefficient = 1;
   obj.geom[0].OnCollision += OnCollision;

   return false;
  }
  public void Update(float dt)
  {
   gt += dt * 5;
   if (gt > 5) gt = 0;
   uvpos.X = ((int)gt) / 6.0f;

   dx = 0; dy = 0;

   #region HOLD_ON
   if (state == PLAYER_STATE.holdOn)
   {
    //upgame
    if (starthand)
    {
     obj.body[0].Position += new Vector2(-Math.Sign(holdDir.X) * 0.3f, 1) * 5 * dt;
     if ((obj.body[0].Position - holdPos).Length() > 1.5f)
     {
      obj.body[0].Enabled = true;
      state = PLAYER_STATE.inAir;
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

   if (dx > 0) { uvmul = new Vector2(-1.0f / 6.0f, 0.5f); uvpos.Y = 0.5f; }
   if (dx < 0) { uvmul = new Vector2(1.0f / 6.0f, 0.5f); uvpos.Y = 0.5f; }
   if (dx == 0) uvpos.Y = 0;

   if (Mouse.GetState().ScrollWheelValue > p.input.prevm.ScrollWheelValue) p.camera.height -= dt * 300;
   if (Mouse.GetState().ScrollWheelValue < p.input.prevm.ScrollWheelValue) p.camera.height += dt * 300;

   if (dx != 0 && state == PLAYER_STATE.stand) state = PLAYER_STATE.run;
   #endregion

   #region CHECK
   if (dy != 0) { jump = true; state = PLAYER_STATE.inAir; }
   obj.body[0].ApplyImpulse(new Vector2(dx, dy));
   if (obj.body[0].LinearVelocity.X > 5) obj.body[0].LinearVelocity.X = 5;
   if (obj.body[0].LinearVelocity.X < -5) obj.body[0].LinearVelocity.X = -5;
   obj.body[0].Rotation = 0;
   obj.body[0].AngularVelocity = 0;
   obj.body[0].ClearTorque();

   onGround = false;
   #endregion
  }
  public void PostUpdate()
  {
   jump = false;
   obj.Update(0);
   p.camera.Position = obj.Position;
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

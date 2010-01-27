using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerGames.FarseerPhysics.Collisions;
using System;

namespace DarkSide
{
 public class MONSTER
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
  public OBJECT obj = new OBJECT();


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

  public MONSTER()
  {
  }
  public void Init(DEVICE_PACK ip)
  {
   p = ip;
   obj.Init(p, "skeleton", "ui", new Vector2(0.5f, 2), OBJTYPE.all);
   obj.makeBox(0.5f, 2, 60);
   obj.setFriction(2);
   obj.mesh.AnimCount = new Vector2(4, 4);
   obj.mesh.PlayLoop(0.01f, 0, 0); 
   obj.mesh.PlayLoop(1, 0, 1);

   p.gameList.monsterList.Add(this);
  }
  public void Update(float dt)
  {
   obj.Update(dt);


   #region MOVES
   // ТУТ АПДЕЙТ ДВИЖЕНИЯ
   if (onGround == false) dy = 0;

   dx = 1;

   if (dx > 0) { uvmul = new Vector2(1.0f / 6.0f, 0.5f); uvpos.Y = 0.5f; obj.mesh.Multiply = new Vector2(Math.Abs(obj.mesh.Multiply.X) * -1, obj.mesh.Multiply.Y); }
   if (dx < 0) { uvmul = new Vector2(1.0f / 6.0f, 0.5f); uvpos.Y = 0.5f; obj.mesh.Multiply = new Vector2(Math.Abs(obj.mesh.Multiply.X) * 1, obj.mesh.Multiply.Y); }
   if (dx == 0) uvpos.Y = 0;

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
  public void Draw(Effect effect)
  {
   obj.Draw(effect);
  }

 }
}

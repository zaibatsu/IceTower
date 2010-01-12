using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace DarkSide
{
 class PLATFORMER : DrawableGameComponent
 {
  DEVICE_PACK p;
  Effect effect = null;

  PLAYER player = new PLAYER();
  public bool onexit = false;

  #region OBJECTS
  OBJECT ground = new OBJECT();
  MESH2D background = new MESH2D();
  MESH2D oops = new MESH2D();


  OBJECT barrel = new OBJECT();
  OBJECT barrel2 = new OBJECT();
  #endregion

  public PLATFORMER(DEVICE_PACK ip, Game game)
   : base(game)
  {
   p = new DEVICE_PACK();
   p.Content = ip.Content;
   p.ps = ip.ps;
   p.gd = ip.gd;
   p.gdm = ip.gdm;
   p.input = ip.input;
   p.state = ip.state;
   p.scale = ip.scale;
   p.time = ip.time;
   p.objList = new OBJECTLIST();
   p.camera = new CAMERA();
   p.camera.Init(p);
  }
  public override void Initialize()
  {
   base.Initialize();
  }
  protected override void LoadContent()
  {
   effect = p.Content.Load<Effect>("sprite");

   #region OBJECTS
   background.Init(p, "background_1", "background", new Vector2(80, 60), OBJTYPE.all);
   background.Position = new Vector2(0, 0);

   ground.debugVerts = true;
   if (ground.Init(p, "level_1", "level", new Vector2(100, 40), OBJTYPE.all)) onexit = true;
   if (ground.MakeVerts(1000)) onexit = true;
   ground.geom[0].FrictionCoefficient = 0;

   if (barrel.Init(p, "barrel", "level", new Vector2(2, 2), OBJTYPE.all)) onexit = true;
   barrel.MakeCircle(1, 10);
   barrel.Position = new Vector2(0, 0);
   barrel.geom[0].FrictionCoefficient = 2;

   if (barrel2.Init(p, "barrel", "level", new Vector2(2, 2), OBJTYPE.all)) onexit = true;
   barrel2.MakeCircle(1, 10);
   barrel2.Position = new Vector2(0, 6);
   barrel2.geom[0].FrictionCoefficient = 2;


   oops.Init(p, "oops_1", "oops", new Vector2(3, 3), OBJTYPE.updateOnly);
   #endregion

   player.Init(p);
   player.Position = new Vector2(3, 3);
  }
  public override void Update(GameTime gameTime)
  {
   if (p.state != GAMESTATE.platformer) return;
   if (onexit) return;
   float dt = p.time.dt;

   player.Update(dt);
   p.ps.Update(dt);
   player.PostUpdate();

   background.Position = player.Position;
   oops.Position = player.Position + new Vector2(2, 2);

   p.objList.Update(dt);
   p.camera.Update();

   ground.Update(dt);

   base.Update(gameTime);
  }
  public override void Draw(GameTime gameTime)
  {
   if (p.state != GAMESTATE.platformer) return;
   effect.Parameters["viewProj"].SetValue(p.camera.view * p.camera.proj);


   effect.Begin();
   effect.CurrentTechnique.Passes[0].Begin();


   p.objList.Draw(effect);
   player.Draw(effect);
   if (oops.Position.Y < -3) oops.Draw(effect);

   effect.CurrentTechnique.Passes[0].End();
   effect.End();

   player.contactDraw();
   // ground.debugVertsDraw(0);

   base.Draw(gameTime);
  }

 }//class
}//namespace

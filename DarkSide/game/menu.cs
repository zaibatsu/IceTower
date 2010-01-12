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
 class MENU : DrawableGameComponent
 {
  DEVICE_PACK p;
  Effect effect = null;
  MESH2D new_game = new MESH2D();
  MESH2D save_load = new MESH2D();
  MESH2D settings = new MESH2D();
  MESH2D quit = new MESH2D();

  int butI = 0;


  public MENU(DEVICE_PACK ip, Game game)
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
   new_game.Init(p, "new_game", "ui", new Vector2(200, 100), OBJTYPE.drawOnly);
   new_game.UIPosition = new Vector2(320, 60 + 360);
   new_game.AnimCount = new Vector2(5, 3);
   new_game.PlayLoop(1, 0, 1);


   save_load.Init(p, "save_load", "ui", new Vector2(200, 100), OBJTYPE.drawOnly);
   save_load.UIPosition = new Vector2(320, 60+240);
   save_load.AnimCount = new Vector2(5, 3);

   settings.Init(p, "settings", "ui", new Vector2(200, 100), OBJTYPE.drawOnly);
   settings.UIPosition = new Vector2(320, 60 + 120);
   settings.AnimCount = new Vector2(5, 3);

   quit.Init(p, "quit", "ui", new Vector2(200, 100), OBJTYPE.all);
   quit.UIPosition = new Vector2(320, 60);
   quit.AnimCount = new Vector2(5, 3);


   effect = p.Content.Load<Effect>("sprite");
  }
  public override void Update(GameTime gameTime)
  {
   p.objList.Update(p.time.dt);

   if (p.input.isKeyJustDown(Keys.Down))
   {
    butI++;
    if (butI > 3) butI = 0;
    new_game.Stop();
    save_load.Stop();
    settings.Stop();
    quit.Stop();
    if (butI == 0) new_game.PlayLoop(1, 0, 1);
    if (butI == 1) save_load.PlayLoop(1, 0, 1);
    if (butI == 2) settings.PlayLoop(1, 0, 1);
    if (butI == 3) quit.PlayLoop(1, 0, 1);
   }
   if (p.input.isKeyJustDown(Keys.Up))
   {
    butI--;
    if (butI < 0) butI = 3;
    new_game.Stop();
    save_load.Stop();
    settings.Stop();
    quit.Stop();
    if (butI == 0) new_game.PlayLoop(1, 0, 1);
    if (butI == 1) save_load.PlayLoop(1, 0, 1);
    if (butI == 2) settings.PlayLoop(1, 0, 1);
    if (butI == 3) quit.PlayLoop(1, 0, 1);
   }
  }
  public override void Draw(GameTime gameTime)
  {
   if (p.state != GAMESTATE.menu) return;
   p.gd.Clear(Color.Black);
   effect.Parameters["viewProj"].SetValue(Matrix.CreateOrthographicOffCenter(0, 640, 0, 480, 0, 100));

   effect.Begin();
   effect.CurrentTechnique.Passes[0].Begin();
   p.objList.Draw(effect);
   effect.CurrentTechnique.Passes[0].End();
   effect.End();

   base.Draw(gameTime);
  }


 }//class
}//namespace

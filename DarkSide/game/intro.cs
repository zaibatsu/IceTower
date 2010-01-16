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
 class INTRO : DrawableGameComponent
 {
  DEVICE_PACK p;
  Effect effect = null;

  public INTRO(DEVICE_PACK ip, Game game)
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
  }
  public override void Update(GameTime gameTime)
  {
   p.objList.Update(p.time.dt);
  }
  public override void Draw(GameTime gameTime)
  {
   if (p.state != GAMESTATE.intro) return;
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

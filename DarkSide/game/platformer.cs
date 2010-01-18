using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FarseerGames.FarseerPhysics;

namespace DarkSide
{
 public class PLATFORMER : DrawableGameComponent
 {
  public DEVICE_PACK p = null;
  Effect effect = null;
  string scriptname;

  MESH2D oops = null;
  MESH2D background = null;
  public PLAYER player = null;


  public PLATFORMER(DEVICE_PACK ip, Game game, string iscriptname)
   : base(game)
  {
   p = new DEVICE_PACK(ip);
   p.ps = new PhysicsSimulator(new Vector2(0, -10));
   p.objList = new OBJECTLIST();
   p.camera = new CAMERA();
   p.camera.Init(p);
   scriptname = iscriptname;
  }
  public override void Initialize()
  {
   base.Initialize();
  }
  protected override void LoadContent()
  {
   effect = p.Content.Load<Effect>("effects/sprite");

   p.lua.Run(scriptname, p, "platp");
   oops = p.lua.getObject("oops") as MESH2D;
   background = p.lua.getObject("background") as MESH2D;

   player = p.lua.getObject("player") as PLAYER;
  }
  public override void Update(GameTime gameTime)
  {
   if (p.state.instance != GAMESTATE.ENUM.platformer) return;
   float dt = p.time.dt;

   if (p.input.isKeyJustDown(Keys.Escape))
   {
    p.state.instance = GAMESTATE.ENUM.menu;
    return;
   }


   player.Update(dt);
   p.ps.Update(dt);
   player.PostUpdate();

   background.Position = player.Position;
   oops.Position = player.Position + new Vector2(2, 2);
   p.camera.Position = player.Position;

   p.objList.Update(dt);
   p.camera.Update();

   base.Update(gameTime);
  }
  public override void Draw(GameTime gameTime)
  {
   if (p.state.instance != GAMESTATE.ENUM.platformer) return;
   effect.Parameters["viewProj"].SetValue(p.camera.view * p.camera.proj);


   effect.Begin();
   effect.CurrentTechnique.Passes[0].Begin();


   p.objList.Draw(effect);
   player.Draw(effect);
   if (oops.Position.Y < -3) oops.Draw(effect);

   effect.CurrentTechnique.Passes[0].End();
   effect.End();

   player.contactDraw();
   OBJECT ground = p.lua.getObject("ground") as OBJECT;
   ground.debugVertsDraw(0);

   base.Draw(gameTime);
  }
  public void CallLoadContent()
  {
   LoadContent();
  }

 }//class
}//namespace

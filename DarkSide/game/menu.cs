using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DarkSide
{
 class MENU : DrawableGameComponent
 {
  DEVICE_PACK p;
  Effect effect = null;
  MESH2D new_game = null;
  MESH2D save_load = null;
  MESH2D settings = null;
  MESH2D quit = null;

  int butI = 0;


  public MENU(DEVICE_PACK ip, Game game)
   : base(game)
  {
   p = new DEVICE_PACK(ip);
   p.gameList = new GAMELIST();
   p.camera = new CAMERA();
   p.camera.Init(p);
  }
  public override void Initialize()
  {
   base.Initialize();
  }
  protected override void LoadContent()
  {
   effect = p.Content.Load<Effect>("effects/sprite");
   p.lua.Run("menuInit", p, "menup");

   new_game = p.lua.getObject("new_game") as MESH2D;
   save_load = p.lua.getObject("save_load") as MESH2D;
   settings = p.lua.getObject("settings") as MESH2D;
   quit = p.lua.getObject("quit") as MESH2D;
  }
  public override void Update(GameTime gameTime)
  {
   p.gameList.Update(p.time.dt);
   if (p.state.instance != GAMESTATE.ENUM.menu) return;

   if (p.input.isKeyJustDown(Keys.Enter) && butI == 0)
   {
    p.state.instance = GAMESTATE.ENUM.newplatformer;
    return;
   }
   if (p.input.isKeyJustDown(Keys.Enter) && butI == 3)
   {
    p.state.instance = GAMESTATE.ENUM.quit;
    return;
   }

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
   if (p.state.instance != GAMESTATE.ENUM.menu) return;
   p.gd.Clear(Color.Black);
   effect.Parameters["viewProj"].SetValue(Matrix.CreateOrthographicOffCenter(0, 640, 0, 480, 0, 100));

   effect.Begin();
   effect.CurrentTechnique.Passes[0].Begin();
   p.gameList.Draw(effect);
   effect.CurrentTechnique.Passes[0].End();
   effect.End();

   base.Draw(gameTime);
  }
  public void CallLoadContent()
  {
   LoadContent();
  }

 }//class
}//namespace

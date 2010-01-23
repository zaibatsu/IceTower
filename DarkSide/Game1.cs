using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DarkSide
{
 public class GAMESTATE
 {
  public enum ENUM
  {
   platformer,
   newplatformer,
   menu,
   settings,
   save_load,
   intro,
   map,
   city,
   quit,
  }
  public GAMESTATE.ENUM instance = GAMESTATE.ENUM.menu;
 }

 public class Game1 : Microsoft.Xna.Framework.Game
 {
  #region INSTANCE
  private static Game1 _instance = null;
  public static Game1 Instance
  {
   get
   {
    if (_instance == null)
    {
     _instance = new Game1();
    }
    return _instance;
   }
  }
  #endregion

  public DEVICE_PACK p = new DEVICE_PACK();
  FPS fps = new FPS();

  public PLATFORMER platformer = null;
  MENU menu = null;

  public Game1()
  {
   _instance = this;
   p.gdm = new GraphicsDeviceManager(this);
   p.gdm.PreferredBackBufferWidth = 640;
   p.gdm.PreferredBackBufferHeight = 480;

   Content.RootDirectory = "Content";
  }
  protected override void Initialize()
  {
   p.time = new TIME();
   p.scale = new Vector2(1, 1);
   p.state = new GAMESTATE();
   p.gd = GraphicsDevice;
   p.Content = Content;
   p.camera = new CAMERA();
   p.input = new INPUT();
   p.lua = new LUA();
   p.lua.Init("init", p);

   menu = new MENU(p, this);
   Components.Add(menu);

   base.Initialize();
  }
  protected override void LoadContent()
  {
   Window.Title = "DarkSide";
   IsMouseVisible = true;

   p.gd.RenderState.CullMode = CullMode.None;
   p.gd.RenderState.AlphaBlendEnable = true;
   p.gd.RenderState.SourceBlend = Blend.SourceAlpha;
   p.gd.RenderState.DestinationBlend = Blend.InverseSourceAlpha;
   p.gd.RenderState.DepthBufferEnable = false;

   for (int i = 0; i < 16; ++i)
   {
    p.gd.SamplerStates[i].AddressU = TextureAddressMode.Clamp;
    p.gd.SamplerStates[i].AddressV = TextureAddressMode.Clamp;
    p.gd.SamplerStates[i].MagFilter = TextureFilter.Linear;
    p.gd.SamplerStates[i].MinFilter = TextureFilter.Linear;
    p.gd.SamplerStates[i].MipFilter = TextureFilter.Linear;
   }
  }
  protected override void Update(GameTime gameTime)
  {
   if (p.state.instance == GAMESTATE.ENUM.quit) Exit();
   if (p.state.instance == GAMESTATE.ENUM.newplatformer)
   {
    if (platformer != null) Components.Remove(platformer);
    platformer = new PLATFORMER(p, this, "platInit1");
    Components.Add(platformer);
    p.state.instance = GAMESTATE.ENUM.platformer;
   }

   p.time.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
   p.input.PreInput();

   fps.Update(p.time.dt);

   base.Update(gameTime);
   p.input.PostInput();
  }
  protected override void Draw(GameTime gameTime)
  {
   p.gd.Clear(Color.CornflowerBlue);
   base.Draw(gameTime);
  }

  #region EDITOR
  protected void InitializeEditor(GraphicsDevice gd)
  {
   p.time = new TIME();
   p.scale = new Vector2(1, 1);
   p.state = new GAMESTATE();
   p.gd = gd;
   p.Content = Content;
   p.camera = new CAMERA();
   p.input = new INPUT();
   p.lua = new LUA();
   p.lua.Init("init", p);

   menu = new MENU(p, this);
   Components.Add(menu);

   base.Initialize();
  }
  public void InitEditor(GraphicsDevice gd, IServiceProvider gs, string platname)
  {
   Content = new ContentManager(gs);
   Content.RootDirectory = "Content";
   InitializeEditor(gd);
   LoadContent();

   platformer = new PLATFORMER(p, this, platname);
   platformer.Initialize();
   platformer.CallLoadContent();
   Components.Add(platformer);
   p.state.instance = GAMESTATE.ENUM.platformer;
   platformer.p.camera.state = CAMERA.STATE.free;
  }
  public void UpdateEditor(float dt)
  {
   TimeSpan t1 = new TimeSpan(0, 0, 0, 0);
   TimeSpan t2 = new TimeSpan(0, 0, 0, (int)dt, (int)((dt - (int)dt) * 1000));
   GameTime gameTime = new GameTime(t1, t1, t1, t2);
   Update(gameTime);
   Draw(gameTime);
  }
  #endregion


 }//main
}//namespace

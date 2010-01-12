using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using FarseerGames.FarseerPhysics;
using FarseerGames.FarseerPhysics.Collisions;
using FarseerGames.FarseerPhysics.Dynamics;
using FarseerGames.FarseerPhysics.Factories;

namespace DarkSide
{
 enum GAMESTATE
 {
  platformer,
  menu,
  settings,
  save_load,
  intro,
  map,
  city,
 }
 public class Game1 : Microsoft.Xna.Framework.Game
 {
  #region DEVICE_PACK
  DEVICE_PACK p = new DEVICE_PACK();
  FPS fps = new FPS();
  #endregion

  PLATFORMER platformer = null;
  MENU menu = null;

  public Game1()
  {
   p.gdm = new GraphicsDeviceManager(this);
   p.gdm.PreferredBackBufferWidth = 640;
   p.gdm.PreferredBackBufferHeight = 480;
  
   Content.RootDirectory = "Content";

  }
  protected override void Initialize()
  {
   p.time = new TIME();
   p.scale = new Vector2(1, 1);
   p.state = GAMESTATE.menu;
   p.gd = GraphicsDevice;
   p.Content = Content;
   p.camera = new CAMERA();
   p.input = new INPUT();
   p.ps = new PhysicsSimulator(new Vector2(0,-10));

   platformer = new PLATFORMER(p, this);
   Components.Add(platformer);
   menu = new MENU(p, this);
   Components.Add(menu);

   base.Initialize();
  }
  protected override void LoadContent()
  {
   Window.Title = "DarkSide";
   IsMouseVisible = true;

   GraphicsDevice.RenderState.CullMode = CullMode.None;
   GraphicsDevice.RenderState.AlphaBlendEnable = true;
   GraphicsDevice.RenderState.SourceBlend = Blend.SourceAlpha;
   GraphicsDevice.RenderState.DestinationBlend = Blend.InverseSourceAlpha;
   GraphicsDevice.RenderState.DepthBufferEnable = false;

   for (int i = 0; i < 16; ++i)
   {
    GraphicsDevice.SamplerStates[i].AddressU = TextureAddressMode.Clamp;
    GraphicsDevice.SamplerStates[i].AddressV = TextureAddressMode.Clamp;
    GraphicsDevice.SamplerStates[i].MagFilter = TextureFilter.Linear;
    GraphicsDevice.SamplerStates[i].MinFilter = TextureFilter.Linear;
    GraphicsDevice.SamplerStates[i].MipFilter = TextureFilter.Linear;
   }
  }
  protected override void Update(GameTime gameTime)
  {
   if (platformer.onexit) { Exit(); return; }
   p.time.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
   p.input.PreInput();

   fps.Update(p.time.dt);

   base.Update(gameTime);
   p.input.PostInput();
  }
  protected override void Draw(GameTime gameTime)
  {
   GraphicsDevice.Clear(Color.CornflowerBlue);

   Window.Title = Mouse.GetState().X.ToString() + "  "  + (480-Mouse.GetState().Y).ToString();

   base.Draw(gameTime);
  }

 }//main
}//namespace

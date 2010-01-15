﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using DarkSide;

namespace platEditor
{
 class GameControl : GraphicsDeviceControl
 {
  private static GameControl _instance = null;
  public static GameControl Instance
  {
   get
   {
    if (_instance == null)
    {
     _instance = new GameControl();
    }
    return _instance;
   }
  }

  public GameControl()
  {
   _instance = this;
  }
  Stopwatch timer;
  public Game1 game = null;
  float gametime = 0;

  protected override void Initialize()
  {
   game = new Game1();
   game.InitEditor(GraphicsDevice, Services);

   timer = Stopwatch.StartNew();
   Application.Idle += delegate { Invalidate(); };
  }
  protected override void Draw()
  {
   float dt = (float)timer.Elapsed.TotalSeconds - gametime;
   game.UpdateEditor(dt);
   gametime = (float)timer.Elapsed.TotalSeconds;
  }
 }
}

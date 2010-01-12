using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DarkSide
{
 class INPUT
 {
  public KeyboardState prevk;
  KeyboardState nowk;
  public MouseState prevm;
  MouseState nowm;

  public bool isKeyJustDown(Keys key) { return nowk.IsKeyDown(key) && !prevk.IsKeyDown(key); }
  public bool isKeyDown(Keys key) { return nowk.IsKeyDown(key); }
  public bool isKeyUp(Keys key) { return nowk.IsKeyUp(key); }
  public void PreInput()
  {
   nowk = Keyboard.GetState();
   nowm = Mouse.GetState();
  }
  public void PostInput()
  {
   prevk = nowk;
   prevm = nowm;
  }
 }
}

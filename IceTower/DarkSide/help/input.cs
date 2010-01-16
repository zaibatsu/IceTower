using Microsoft.Xna.Framework.Input;

namespace DarkSide
{
 public class INPUT
 {
  private KeyboardState prevk;
  private KeyboardState nowk;
  private MouseState prevm;
  private MouseState nowm;

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
  public int ScrollWheelValueNow  { get{ return nowm.ScrollWheelValue; } }
  public int ScrollWheelValuePrev { get{ return prevm.ScrollWheelValue; } }

 }//class
}//namespace

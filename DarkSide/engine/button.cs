using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace DarkSide
{
 class BUTTON : IUPDATABLE
 {
  public OBJTYPE type { get; set; }
  private MESH2D mesh = new MESH2D();
  public float state { get; set; }

  public Vector2 Position { get; set; }
  public void Init(DEVICE_PACK p, string texname, Vector2 wh)
  {
   state = 0;
   mesh.Init(p, texname, "level", wh, OBJTYPE.none);
  }
  public void Update(float dt)
  {
   mesh.Position = new Vector2(0, state / 3.0f);
  }
  public void Draw(Effect effect)
  {
   mesh.Draw(effect);
  }

 }//class
}//namespace

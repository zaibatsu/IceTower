using System.Collections.Generic;
using Microsoft.Xna.Framework;
using FarseerGames.FarseerPhysics.Collisions;

namespace DarkSide
{
 class Level
 {
  private OBJECT obj = new OBJECT();
  public Level()  { }

  public List<Vertices> getVertices() { return obj.vertsList; }
  public bool Init(DEVICE_PACK p)
  {
   obj.debugVerts = true;
   if (obj.Init(p, "level_1", "level", new Vector2(100, 40), OBJTYPE.all)) return true;
   if (obj.MakeVerts(1000)) return true;

   return false;
  }
 }
}

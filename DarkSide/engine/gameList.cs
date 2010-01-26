using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace DarkSide
{
 public class GAMELIST
 {
  public List<MONSTER>    monsterList = new List<MONSTER>();
  public List<OBJECT>     objList = new List<OBJECT>();
  public List<IDRAWABLE>  meshList = new List<IDRAWABLE>();

   
  public void Update(float dt)
  {
   foreach (OBJECT obj in objList)
   {
    if (obj.type == OBJTYPE.all || obj.type == OBJTYPE.updateOnly) obj.Update(dt);
   }
   foreach (MONSTER mob in monsterList)
   {
    mob.Update(dt);
   }
  }
  public void Draw(Effect effect)
  {
   foreach (IDRAWABLE obj in meshList)
   {
    if (obj.type == OBJTYPE.all || obj.type == OBJTYPE.drawOnly) obj.Draw(effect);
   }
   foreach (IOBJECT obj in objList)
   {
    if (obj.type == OBJTYPE.all || obj.type == OBJTYPE.drawOnly) obj.Draw(effect);
   }
   foreach (MONSTER mob in monsterList)
   {
    mob.Draw(effect);
   }
  }
  public void debugDraw()
  {
   foreach (OBJECT obj in objList)
   {
    if (obj.type == OBJTYPE.all || obj.type == OBJTYPE.drawOnly) obj.debugDraw();
   }
  }

 }//class
}//namespace

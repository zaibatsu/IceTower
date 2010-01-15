using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace DarkSide
{
 public class OBJECTLIST
 {
  private List<IOBJECT> objList = new List<IOBJECT>();
  private List<IDRAWABLE> drawList = new List<IDRAWABLE>();
  private List<IUPDATABLE> updateList = new List<IUPDATABLE>();

  public void Add(IOBJECT iobj, OBJTYPE type) { iobj.type = type; objList.Add(iobj); }
  public void AddDraw(IDRAWABLE iobj, OBJTYPE type) { iobj.type = type; drawList.Add(iobj); }
  public void AddUpdate(IUPDATABLE iobj, OBJTYPE type) { iobj.type = type; updateList.Add(iobj); }

  public void Remove(IOBJECT iobj) { objList.Remove(iobj); }
  public void RemoveDraw(IDRAWABLE iobj) { drawList.Remove(iobj); }
  public void RemoveUpdate(IUPDATABLE iobj) { updateList.Remove(iobj); }

  public IOBJECT this[int i] { get { return objList[i]; } }
  public void Update(float dt)
  {
   foreach (IUPDATABLE obj in updateList)
   {
    if (obj.type == OBJTYPE.all || obj.type == OBJTYPE.updateOnly) obj.Update(dt);
   }
   foreach (IOBJECT obj in objList)
   {
    if (obj.type == OBJTYPE.all || obj.type == OBJTYPE.updateOnly) obj.Update(dt);
   }
  }
  public void Draw(Effect effect)
  {
   foreach (IDRAWABLE obj in drawList)
   {
    if (obj.type == OBJTYPE.all || obj.type == OBJTYPE.drawOnly) obj.Draw(effect);
   }
   foreach (IOBJECT obj in objList)
   {
    if (obj.type == OBJTYPE.all || obj.type == OBJTYPE.drawOnly) obj.Draw(effect);
   }
  }

 }//class
}//namespace

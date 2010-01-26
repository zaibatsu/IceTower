using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DarkSide
{
 public class MONSTER
 {
  public OBJECT obj { get; set; }

  public MONSTER()
  {
  }
  public void Init(DEVICE_PACK p)
  {
   obj.Init(p, "skeleton", "plat", new Vector2(0.5f, 2), OBJTYPE.all);
   obj.makeBox(0.5f, 2, 60);
   obj.setFriction(2);

   p.gameList.monsterList.Add(this);
  }
  public void Update(float dt)
  {
   obj.Update(dt);
  }
  public void Draw(Effect effect)
  {
   obj.Draw(effect);
  }

 }
}

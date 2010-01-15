using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using FarseerGames.FarseerPhysics;

namespace DarkSide
{
 public enum OBJTYPE
 {
  drawOnly=0,
  updateOnly=1,
  all=2,
  none=3
 }
 public interface IUPDATABLE
 {
  OBJTYPE type { get; set; }
  void Update(float dt);
 }
 public interface IDRAWABLE
 {
  OBJTYPE type { get; set; }
  void Draw(Effect effect);
 }
 public interface IOBJECT : IUPDATABLE, IDRAWABLE
 {
  new OBJTYPE type { get; set; }
 }
 public interface IREMOVABLE
 {
  void Remove();
 }

 interface IDEVICE_PACK
 {
  GraphicsDevice gd { get; set; }
  GraphicsDeviceManager gdm { get; set; }
  ContentManager Content { get; set; }
  CAMERA camera { get; set; }
  INPUT input { get; set; }
  PhysicsSimulator ps { get; set; }
  OBJECTLIST objList { get; set; }
  GAMESTATE state { get; set; }
  Vector2 scale { get; set; }
  TIME time { get; set; }
  LUA lua { get; set; }
 }
 public class DEVICE_PACK : IDEVICE_PACK
 {
  public GraphicsDevice gd { get; set; }
  public GraphicsDeviceManager gdm { get; set; }
  public ContentManager Content { get; set; }
  public PhysicsSimulator ps { get; set; }
  public CAMERA camera { get; set; }
  public INPUT input { get; set; }
  public OBJECTLIST objList { get; set; }
  public GAMESTATE state { get; set; }
  public Vector2 scale { get; set; }
  public TIME time { get; set; }
  public LUA lua { get; set; }

  public DEVICE_PACK() {}
  public DEVICE_PACK(DEVICE_PACK ip)
  {
   Init(ip);
  }
  public void Init(DEVICE_PACK ip)
  {
   Content = ip.Content;
   ps = ip.ps;
   gd = ip.gd;
   gdm = ip.gdm;
   input = ip.input;
   state = ip.state;
   scale = ip.scale;
   time = ip.time;
   lua = ip.lua;
   time = ip.time;
  }

  public static OBJTYPE typeByName(string name)
  {
   if (name == "drawOnly") return OBJTYPE.drawOnly;
   else if (name == "updateOnly") return OBJTYPE.updateOnly;
   else if (name == "all") return OBJTYPE.all;
   else return OBJTYPE.none;
  }


 }//class 
}//namespace

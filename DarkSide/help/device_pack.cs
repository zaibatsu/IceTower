using FarseerGames.FarseerPhysics;
using FarseerGames.FarseerPhysics.Dynamics;
using FarseerGames.FarseerPhysics.Factories;
using FarseerGames.FarseerPhysics.Collisions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace DarkSide
{
 enum OBJTYPE
 {
  drawOnly,
  updateOnly,
  all,
  none
 }
 interface IUPDATABLE
 {
  OBJTYPE type { get; set; }
  void Update(float dt);
 }
 interface IDRAWABLE
 {
  OBJTYPE type { get; set; }
  void Draw(Effect effect);
 }
 interface IOBJECT : IUPDATABLE, IDRAWABLE
 {
  new OBJTYPE type { get; set; }
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
 }
 class DEVICE_PACK : IDEVICE_PACK
 {
  public GraphicsDevice gd { get; set; }
  public GraphicsDeviceManager gdm { get; set; }
  public ContentManager Content { get; set; }
  public CAMERA camera { get; set; }
  public INPUT input { get; set; }
  public PhysicsSimulator ps { get; set; }
  public OBJECTLIST objList { get; set; }
  public GAMESTATE state { get; set; }
  public Vector2 scale { get; set; }
  public TIME time { get; set; }
 }
}//namespace

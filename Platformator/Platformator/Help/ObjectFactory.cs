using DarkSide;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using FarseerGames.FarseerPhysics.Dynamics;
using FarseerGames.FarseerPhysics.Factories;
using FarseerGames.FarseerPhysics.Collisions;

namespace Platformator
{
 class ObjectFactory
 {
  private static ObjectFactory _instance = null;
  public static ObjectFactory Instance
  {
   get
   {
    if (_instance == null)
    {
     _instance = new ObjectFactory();
    }
    return _instance;
   }
  }

  public List<OBJECT> objList = new List<OBJECT>();
  public bool click = false;

  public void addBox(DEVICE_PACK p)
  {
   OBJECT obj = new OBJECT();
   obj.Init(p, "cibylia", "ui", new Vector2(1, 1), OBJTYPE.all);
   obj.MakeCircle(0.7f, 10);
   obj.Position = new Vector2(0, 10);
   objList.Add(obj);
   click = true;
  }
  public void addCibylia(DEVICE_PACK p)
  {
   OBJECT obj = new OBJECT();
   obj.Init(p, "cibylia", "ui", new Vector2(1, 1), OBJTYPE.all);
   obj.MakeCircle(0.7f, 10);
   obj.Position = new Vector2(0, 10);
   objList.Add(obj);
   click = true;
  }
  public string setPos(int x,int y)
  {
   if (objList.Count == 0) return "";
   if (x > 640 || y > 480) return "";
   if (x < 0 || y < 0) return "";

   Vector3 pos0 = new Vector3(x, y, 0);
   Vector3 pos1 = new Vector3(x, y, 1);
   CAMERA camera = GameControl.Instance.game.platformer.p.camera;
   Vector3 p0 = GameControl.Instance.game.platformer.p.gd.Viewport.Unproject(pos0, camera.proj, camera.view, Matrix.Identity);
   Vector3 p1 = GameControl.Instance.game.platformer.p.gd.Viewport.Unproject(pos1, camera.proj, camera.view, Matrix.Identity);
   Vector3 dir = Vector3.Normalize(p1 - p0);
   Vector3 pos = camera.eye;

   Plane plane = new Plane(new Vector3(0, 0, -1), 0);

   Ray ray = new Ray(pos, dir);
   float? ri = ray.Intersects(plane);

   if(ri != null)
   {
    pos += dir * ri.Value;
   }

   objList[objList.Count - 1].Position = new Vector2(pos.X, pos.Y);
   objList[objList.Count - 1].body[0].ClearForce();
   objList[objList.Count - 1].body[0].ClearImpulse();
   objList[objList.Count - 1].body[0].ClearTorque();
   objList[objList.Count - 1].body[0].LinearVelocity = Vector2.Zero;
   objList[objList.Count - 1].body[0].AngularVelocity = 0;

   return ray.ToString();
  }

 }//class
}//namespace

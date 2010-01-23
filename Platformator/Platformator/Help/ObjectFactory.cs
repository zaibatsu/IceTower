using DarkSide;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
  public List<Texture2D> texList = new List<Texture2D>();
  public OBJECT focusObj = null;
  public bool click = false;

  public Vector2 focusPos = new Vector2(0, -1000);


  public GEOMTYPE nextGeomType = GEOMTYPE.none;
  public int boxCount = 0;
  public int ellipseCount = 0;
  public int circleCount = 0;
  public int textureGeomCount = 0;


  public void addBox(DEVICE_PACK p, string iname, string texture, Vector2 wh, Vector2 physWH, float mass, float friction, bool isStatic)
  {
   OBJECT obj = new OBJECT();
   obj.Init(p, texture, "ui", wh, OBJTYPE.all);
   obj.makeBox(physWH.X, physWH.Y, mass);
   obj.Position = new Vector2(0, -1000);
   obj.setFriction(friction);
   obj.setStatic(isStatic);
   obj.name = iname;
   objList.Add(obj);
   click = true;
   focusObj = obj;
   if (focusPos != new Vector2(0, -1000)) obj.Position = focusPos;
   boxCount++;
  }
  public void removeLast()
  {
   focusPos = objList[objList.Count - 1].Position;
   objList[objList.Count - 1].Delete();
   if (objList[objList.Count - 1].geomType == GEOMTYPE.box) boxCount--;
   objList.Remove(objList[objList.Count - 1]);
   focusObj = null;
  }
  public string setPos(int x, int y)
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

   if (ri != null)
   {
    pos += dir * ri.Value;
   }

   objList[objList.Count - 1].Position = new Vector2(pos.X, pos.Y);
   objList[objList.Count - 1].objDesc[0].body.ClearForce();
   objList[objList.Count - 1].objDesc[0].body.ClearImpulse();
   objList[objList.Count - 1].objDesc[0].body.ClearTorque();
   objList[objList.Count - 1].objDesc[0].body.LinearVelocity = Vector2.Zero;
   objList[objList.Count - 1].objDesc[0].body.AngularVelocity = 0;

   return ray.ToString();
  }

  public OBJECT Intersect(int x, int y)
  {
   if (objList.Count == 0) return null;
   if (x > 640 || y > 480) return null;
   if (x < 0 || y < 0) return null;

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

   if (ri != null)
   {
    pos += dir * ri.Value;
   }

   Vector2 pos2 = new Vector2(pos.X, pos.Y);
   foreach (OBJECT obj in objList)
   {
    if ((obj.Position - pos2).Length() < obj.mesh.wh.Length()) return obj;
   }

   return null;
  }

 }//class
}//namespace

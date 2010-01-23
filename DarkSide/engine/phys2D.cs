using System.Collections.Generic;
using FarseerGames.FarseerPhysics.Dynamics;
using FarseerGames.FarseerPhysics.Collisions;
using Microsoft.Xna.Framework.Graphics;
using FarseerGames.FarseerPhysics.Factories;
using Microsoft.Xna.Framework;

namespace DarkSide
{
 public enum GEOMTYPE
 {
  box,
  circle,
  ellipse,
  verts,
  multigeom,
  none
 }
 public class OBJ_DESC
 {
  DEVICE_PACK p = null;

  public Vector2 wh { get; set; }
  public float radius { get; set; }
  public float xradius{ get; set; }
  public float yradius { get; set; }
  public Texture2D tex { get; set; }
  public Geom geom { get; set; }
  public Body body { get; set; }
  public float mass { get; set; }
  public GEOMTYPE geomType { get; set; }
  public GEOMTYPE globalGeomType { get; set; }
  public Vertices verts { get; set; }

  private const int numedges = 32;
  public const float tonn = 1000;
  public Vector2 Position
  {
   get
   {
    return body.Position;
   }
   set
   {
    body.Position = value;
   }
  }

  public OBJ_DESC(DEVICE_PACK ip)
  {
   p = ip;
   geomType = GEOMTYPE.none;
   globalGeomType = GEOMTYPE.none;
  }
  public void makeBox(float iwidth, float iheight, float imass)
  {
   geomType = GEOMTYPE.box;
   mass = imass;
   wh = new Vector2(iwidth, iheight);
   if(globalGeomType!= GEOMTYPE.multigeom) body = BodyFactory.Instance.CreateRectangleBody(p.ps, wh.X, wh.Y, mass);
   geom = GeomFactory.Instance.CreateRectangleGeom(p.ps, body, wh.X, wh.Y);
  }
  public void makeCircle(float iradius, float imass)
  {
   geomType = GEOMTYPE.circle;
   mass = imass;
   radius = iradius;
   if (globalGeomType != GEOMTYPE.multigeom) body = BodyFactory.Instance.CreateCircleBody(p.ps, radius, mass);
   geom = GeomFactory.Instance.CreateCircleGeom(p.ps, body, radius, numedges);
  }
  public void makeEllipse(float ixradius, float iyradius, float imass)
  {
   geomType = GEOMTYPE.ellipse;
   mass = imass;
   xradius = ixradius;
   yradius = iyradius;
   if (globalGeomType != GEOMTYPE.multigeom) body = BodyFactory.Instance.CreateEllipseBody(p.ps, xradius, yradius, mass);
   geom = GeomFactory.Instance.CreateEllipseGeom(p.ps, body, xradius, yradius, numedges);
  }
  public void makeVerts(Vector2 iwh, Texture2D itex)
  {
   geomType = GEOMTYPE.verts;
   wh = iwh;
   tex = itex;
  }

 }
}//namespace

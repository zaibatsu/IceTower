using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using FarseerGames.FarseerPhysics;
using FarseerGames.FarseerPhysics.Dynamics;
using FarseerGames.FarseerPhysics.Factories;
using FarseerGames.FarseerPhysics.Collisions;


namespace DarkSide
{
 class OBJECT : IPHYS2D, IOBJECT
 {
  public OBJTYPE type { get; set; }
  public MESH2D mesh = new MESH2D();
  DEVICE_PACK p;

  #region IPHYS2D
  public psGeomType geomType { get; set; }
  public List<Body> body { get; set; }
  public List<Geom> geom { get; set; }

  private Vector2 centroid;
  private float mass { get; set; }
  private float width { get; set; }
  private float height { get; set; }
  private float radius { get; set; }
  private float xradius { get; set; }
  private float yradius { get; set; }
  private const int numedges = 32;
  private const float tonn = 1000;


  public bool debugVerts { get; set; }
  public List<Vertices> vertsList { get; set; }

  public BasicEffect baseEffect;
  private List<VertexPositionColor[]> vertsDraw = null;


  public Vector2 Position
  {
   set
   {
    for (int i = 0; i < body.Count; ++i)
    {
     if (geomType == psGeomType.geom_verts) body[i].Position = value;
     else body[i].Position = value;
    }
   }
   get { return body[0].Position; }
  }


  public void MakeBox(float iwidth, float iheight, float imass)
  {
   geomType = psGeomType.geom_box;
   mass = imass;
   width = iwidth;
   height = iheight;
   body.Add(BodyFactory.Instance.CreateRectangleBody(p.ps, width, height, mass));
   geom.Add(GeomFactory.Instance.CreateRectangleGeom(p.ps, body[0], width, height));
  }
  public void MakeCircle(float iradius, float imass)
  {
   geomType = psGeomType.geom_circle;
   mass = imass;
   radius = iradius;
   body.Add(BodyFactory.Instance.CreateCircleBody(p.ps, radius, mass));
   geom.Add(GeomFactory.Instance.CreateCircleGeom(p.ps, body[0], radius, numedges));
  }
  public void MakeEllipse(float ixradius, float iyradius, float imass)
  {
   geomType = psGeomType.geom_ellipse;
   mass = imass;
   xradius = ixradius;
   yradius = iyradius;
   body.Add(BodyFactory.Instance.CreateEllipseBody(p.ps, xradius, yradius, mass));
   geom.Add(GeomFactory.Instance.CreateEllipseGeom(p.ps, body[0], xradius, yradius, numedges));
  }
  public bool MakeVerts(float imass)
  {
   mass = imass;
   geomType = psGeomType.geom_verts;

   List<Vertices> temp = new List<Vertices>();

   uint[] data = new uint[mesh.tex.Width * mesh.tex.Height];
   mesh.tex.GetData(data);
   mapCreator map = new mapCreator();
   vertsList = map.getMap(data, mesh.tex.Width, mesh.tex.Height);

   if (vertsList.Count == 0) return true;
   for (int i = 0; i < vertsList.Count; ++i)
   {
    Vector2 min = mapCreator.minV(vertsList[i]);
    Vector2 max = mapCreator.maxV(vertsList[i]);
    centroid = vertsList[i].GetCentroid() * new Vector2(mesh.wh.X / (float)mesh.tex.Width, mesh.wh.Y / (float)mesh.tex.Height);
    temp.Add(new Vertices());
    for (int j = 0; j < vertsList[i].Count; ++j)
    {
     vertsList[i][j] -= new Vector2(mesh.wh.X / 2, mesh.wh.Y / 2);
     vertsList[i][j] *= new Vector2(mesh.wh.X / (float)mesh.tex.Width, -mesh.wh.Y / (float)mesh.tex.Height);

     temp[i].Add(vertsList[i][j]);
    }

    centroid = vertsList[i].GetCentroid();
    Body bodyT = BodyFactory.Instance.CreatePolygonBody(p.ps, vertsList[i], tonn);
    bodyT.IsStatic = true;
    Geom geomT = GeomFactory.Instance.CreatePolygonGeom(p.ps, bodyT, vertsList[i], centroid, 0, 0.5f);
    bodyT.Position = Vector2.Zero;
    centroid = Vector2.Zero;

    body.Add(bodyT);
    geom.Add(geomT);
   }
   vertsList = temp;

   return false;
  }
  public void Deleteps()
  {
   geomType = psGeomType.geom_none;
   for (int i = 0; i < body.Count; ++i)
   {
    body[i].Dispose();
    geom[i].Dispose();
   }
  }
  public void setStatic(bool b)
  {
   for (int i = 0; i < body.Count; ++i) body[i].IsStatic = b;
  }
  public void debugVertsDraw(int index)
  {
   baseEffect.Projection = p.camera.proj;
   baseEffect.View = p.camera.view;
   baseEffect.World = Matrix.CreateRotationZ(body[0].Rotation);
   baseEffect.VertexColorEnabled = true;
   baseEffect.LightingEnabled = false;
   baseEffect.Begin();
   baseEffect.CurrentTechnique.Passes[0].Begin();

   p.gd.VertexDeclaration = new VertexDeclaration(p.gd, VertexPositionColor.VertexElements);

   vertsDraw.Clear();
   for (int i = 0; i < vertsList.Count; ++i)
   {
    VertexPositionColor[] temp = new VertexPositionColor[vertsList[i].Count];
    vertsDraw.Add(temp);
    for (int j = 0; j < vertsList[i].Count; ++j)
    {
     vertsDraw[i][j].Position = new Vector3(vertsList[i][j] + body[i].Position, 0);
     vertsDraw[i][j].Color = Color.Black;
    }
    p.gd.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineStrip, vertsDraw[i], 0, vertsList[i].Count - 1);
    p.gd.RenderState.PointSize = 4;
    p.gd.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.PointList, vertsDraw[i], 0, vertsList[i].Count);
   }

   baseEffect.CurrentTechnique.Passes[0].End();
   baseEffect.End();
  }
  #endregion 

  public OBJECT()
  {
   geomType = psGeomType.geom_none;
   debugVerts = false;
  }

  public bool Init(DEVICE_PACK dp, string itexname, string imodelname, Vector2 iwh, OBJTYPE itype)
  {
   p = dp;

   mesh.Init(p, itexname, imodelname, iwh, OBJTYPE.none );

   #region PHYS
   if (debugVerts) baseEffect = new BasicEffect(p.gd, null);
   body = new List<Body>();
   geom = new List<Geom>();
   vertsDraw = new List<VertexPositionColor[]>();
   #endregion

   if (itype != OBJTYPE.none) p.objList.Add(this, itype);
   mesh.rot = Matrix.CreateRotationZ(0);

   return false;
  }
  public void Update(float dt)
  {
   mesh.rot = Matrix.CreateRotationZ(body[0].Rotation);
   mesh.Position = Position;
  }
  public void Draw(Effect effect)
  {
   mesh.Draw(effect);
  }
 }//class
}//namespace

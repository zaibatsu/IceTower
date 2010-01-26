using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerGames.FarseerPhysics.Dynamics;
using FarseerGames.FarseerPhysics.Factories;
using FarseerGames.FarseerPhysics.Collisions;


namespace DarkSide
{
 public class OBJECT : IOBJECT
 {
  private DEVICE_PACK p = null;

  public OBJTYPE type { get; set; }
  public MESH2D mesh = new MESH2D();
  public GEOMTYPE geomType { get; set; }
  public List<OBJ_DESC> objDesc = new List<OBJ_DESC>();
  public string name = "none";
   
  public Vector2 Position
  {
   set
   {
    foreach (OBJ_DESC obj in objDesc)
    {
     obj.Position = value;
    }
   }
   get { return objDesc[0].Position; }
  }
  public float Rotation
  {
   get
   {
    return objDesc[0].body.Rotation;
   }
   set
   {
    objDesc[0].body.Rotation = value;
   }
  }

  public bool debugVerts { get; set; }
  public BasicEffect baseEffect = null;


  public void makeBox(float iwidth, float iheight, float imass)
  {
   if (geomType != GEOMTYPE.multigeom) geomType = GEOMTYPE.box;
   OBJ_DESC obj = new OBJ_DESC(p);
   if (objDesc.Count != 0 && geomType == GEOMTYPE.multigeom) { obj.globalGeomType = GEOMTYPE.multigeom; obj.body = objDesc[0].body; }
   obj.makeBox(iwidth, iheight, imass);
   objDesc.Add(obj);
  }
  public void makeCircle(float iradius, float imass)
  {
   if (geomType != GEOMTYPE.multigeom) geomType = GEOMTYPE.circle;
   OBJ_DESC obj = new OBJ_DESC(p);
   if (objDesc.Count != 0 && geomType == GEOMTYPE.multigeom) { obj.globalGeomType = GEOMTYPE.multigeom; obj.body = objDesc[0].body; }
   obj.makeCircle(iradius, imass);
   objDesc.Add(obj);
  }
  public void makeEllipse(float ixradius, float iyradius, float imass)
  {
   if (geomType != GEOMTYPE.multigeom) geomType = GEOMTYPE.ellipse;
   OBJ_DESC obj = new OBJ_DESC(p);
   if (objDesc.Count != 0 && geomType == GEOMTYPE.multigeom) { obj.globalGeomType = GEOMTYPE.multigeom; obj.body = objDesc[0].body; }
   obj.makeEllipse(ixradius, iyradius, imass);
   objDesc.Add(obj);
  }
  public bool makeVerts(string texname, Vector2 wh)
  {
   if (geomType != GEOMTYPE.multigeom) geomType = GEOMTYPE.verts;


   Texture2D tex = p.Content.Load<Texture2D>("textures/" + texname);
   if (tex == null) return false;
   uint[] data = new uint[tex.Width * tex.Height];
   tex.GetData(data);
   mapCreator map = new mapCreator();
   List<Vertices> vertsList = map.getMap(data, tex.Width, tex.Height);
   if (vertsList.Count == 0) return true;



   for (int i = 0; i < vertsList.Count; ++i)
   {
    OBJ_DESC obj = new OBJ_DESC(p);
    obj.makeVerts(wh, tex);


    obj.verts = new Vertices();
    for (int j = 0; j < vertsList[i].Count; ++j)
    {
     vertsList[i][j] *= new Vector2(wh.X / (float)mesh.tex.Width, -wh.Y / (float)mesh.tex.Height);
     vertsList[i][j] -= new Vector2(wh.X / 2, -wh.Y / 2);

     obj.verts.Add(vertsList[i][j]);
    }
    obj.verts.Add(obj.verts[0]);



    Vector2 centroid = vertsList[i].GetCentroid();

    //obj.body = BodyFactory.Instance.CreatePolygonBody(p.ps, vertsList[i], OBJ_DESC.tonn);
    if (objDesc.Count != 0 && geomType == GEOMTYPE.multigeom) { obj.globalGeomType = GEOMTYPE.multigeom; obj.body = objDesc[0].body; }
    else obj.body = BodyFactory.Instance.CreatePolygonBody(p.ps, vertsList[i], OBJ_DESC.tonn);

    obj.body.IsStatic = true;
    obj.geom = GeomFactory.Instance.CreatePolygonGeom(p.ps, obj.body, vertsList[i], centroid, 0, 0.5f);
    obj.body.Position = Vector2.Zero;



    objDesc.Add(obj);
   }

   return false;
  }
  public void Delete()
  {
   if (objDesc.Count == 0) return;
   geomType = GEOMTYPE.none;
   foreach (OBJ_DESC obj in objDesc)
   {
    obj.body.Dispose();
    obj.geom.Dispose();
   }
   objDesc.Clear();
   p.gameList.objList.Remove(this);
  }
  public void setStatic(bool b)
  {
   foreach (OBJ_DESC obj in objDesc) obj.body.IsStatic = b;
  }
  public void setFriction(float f)
  {
   foreach (OBJ_DESC obj in objDesc) obj.geom.FrictionCoefficient = f;
  }


  public void debugVertsDraw(int index)
  {
   if (!debugVerts) return;

   p.gd.VertexDeclaration = new VertexDeclaration(p.gd, VertexPositionColor.VertexElements);
   p.gd.RenderState.PointSize = 4;
   baseEffect.Projection = p.camera.proj;
   baseEffect.View = p.camera.view;
   baseEffect.VertexColorEnabled = true;
   baseEffect.LightingEnabled = false;
   baseEffect.Begin();
   baseEffect.CurrentTechnique.Passes[0].Begin();

   foreach (OBJ_DESC obj in objDesc)
   {
    if (obj.geomType != GEOMTYPE.verts) continue;
    baseEffect.World = Matrix.CreateRotationZ(obj.body.Rotation);
    baseEffect.CommitChanges();

    VertexPositionColor[] vertsDraw = new VertexPositionColor[obj.verts.Count];
    for (int j = 0; j < obj.verts.Count; ++j)
    {
     Vector2 centroid = obj.verts.GetCentroid();
     vertsDraw[j].Position = new Vector3(obj.verts[j], 0);
     vertsDraw[j].Color = Color.Black;
    }
    p.gd.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineStrip, vertsDraw, 0, obj.verts.Count - 1);
    p.gd.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.PointList, vertsDraw, 0, obj.verts.Count);
   }

   baseEffect.CurrentTechnique.Passes[0].End();
   baseEffect.End();
  }
  public void debugDraw()
  {
   if (baseEffect == null) baseEffect = new BasicEffect(p.gd, null);


   p.gd.VertexDeclaration = new VertexDeclaration(p.gd, VertexPositionColor.VertexElements);
   p.gd.RenderState.PointSize = 4;
   baseEffect.Projection = p.camera.proj;
   baseEffect.View = p.camera.view;
   baseEffect.VertexColorEnabled = true;
   baseEffect.LightingEnabled = false;
   baseEffect.Begin();
   baseEffect.CurrentTechnique.Passes[0].Begin();

   foreach (OBJ_DESC obj in objDesc)
   {
    //baseEffect.World = ;
    baseEffect.CommitChanges();

    VertexPositionColor[] vertsDraw = new VertexPositionColor[obj.geom.LocalVertices.Count];
    for (int j = 0; j < obj.geom.LocalVertices.Count; ++j)
    {
     vertsDraw[j].Position = new Vector3(obj.geom.LocalVertices[j], 0);
     vertsDraw[j].Position = Vector3.Transform(vertsDraw[j].Position, Matrix.CreateRotationZ(obj.geom.Rotation));
     vertsDraw[j].Position += new Vector3(obj.geom.Position, 0);
     vertsDraw[j].Color = Color.DarkSeaGreen;
    }
    p.gd.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineStrip, vertsDraw, 0, obj.geom.LocalVertices.Count - 1);
    p.gd.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.PointList, vertsDraw, 0, obj.geom.LocalVertices.Count);
   }

   baseEffect.CurrentTechnique.Passes[0].End();
   baseEffect.End();
  }

  public OBJECT()
  {
   debugVerts = false;
  }
  public bool Init(DEVICE_PACK dp, string itexname, string imodelname, Vector2 iwh, string type)
  {
   return Init(dp, itexname, imodelname, iwh, DEVICE_PACK.typeByName(type));
  }
  public bool Init(DEVICE_PACK dp, string itexname, string imodelname, Vector2 iwh, OBJTYPE itype)
  {
   p = dp;
   type = itype;
   mesh.Init(p, itexname, imodelname, iwh, OBJTYPE.none);
   if (debugVerts) baseEffect = new BasicEffect(p.gd, null);
   mesh.rot = Matrix.CreateRotationZ(0);

   if (type != OBJTYPE.none) p.gameList.objList.Add(this);
   return false;
  }
  public void Update(float dt)
  {
   mesh.rot = Matrix.CreateRotationZ(objDesc[0].geom.Rotation);
   mesh.Position = Position;
  }
  public void Draw(Effect effect)
  {
   mesh.Draw(effect);
  }

 }//class
}//namespace

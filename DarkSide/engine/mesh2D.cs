using System.Timers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DarkSide
{
 public class MESH2D : IDRAWABLE
 {
  public OBJTYPE type { get; set; }
  private DEVICE_PACK p;

  #region MESH2D
  public Texture2D tex { get; set; }
  private Model model { get; set; }

  public string texname { get; set; }
  private string modelname { get; set; }

  public Vector4 uv;
  public Matrix rot = new Matrix();
  private Vector4 k;
  public Vector2 wh;
  #endregion

  #region ANIMATION
  enum ANIMTYPE
  {
   loop,
   once,
   _static
  }
  ANIMTYPE animtype = ANIMTYPE._static;
  Vector2 tuv = Vector2.Zero;
  TIMER time = new TIMER();
  Vector2 animcount = new Vector2(1, 1);
  #endregion

  #region 2D
  public Vector2 Multiply
  {
   get { return new Vector2(k.X, k.Y); }
   set { k.X = value.X; k.Y = value.Y; }
  }
  public Vector2 Position
  {
   get { return new Vector2(k.Z, k.W); }
   set { k.Z = value.X; k.W = value.Y; }
  }
  #endregion

  #region UI
  //TEXSCALE texsale = TEXSCALE.xy;
  Vector2 offset = new Vector2(0, 0);
  public Vector2 UIPosition
  {
   get { return new Vector2(k.Z, k.W); }
   set { k.Z = value.X + wh.X * offset.X / 2; k.W = value.Y + wh.Y * offset.Y / 2; }
  }
  #endregion

  public MESH2D() { }
  public bool Init(DEVICE_PACK dp, string itexname, string imodelname, Vector2 iwh, string name)
  {
   return Init(dp, itexname, imodelname, iwh, DEVICE_PACK.typeByName(name));
  }
  public bool Init(DEVICE_PACK dp, string itexname, string imodelname, Vector2 iwh, OBJTYPE itype)
  {
   p = dp;
   wh = iwh;
   k = new Vector4(wh.X, wh.Y, 0, 0);
   uv = new Vector4(1, 1, 0, 0);
   texname = itexname;
   modelname = imodelname;

   tex = null;
   model = null;
   tex = dp.Content.Load<Texture2D>("textures/" + texname);
   model = dp.Content.Load<Model>("models/" + modelname);

   if (tex == null || model == null) return true;
   rot = Matrix.Identity;

   if (itype != OBJTYPE.none) p.gameList.AddDraw(this, itype);
   return false;
  }
  public void Draw(Effect effect)
  {
   Update(0);
   effect.Parameters["world"].SetValue(rot);
   effect.Parameters["k"].SetValue(k);
   effect.Parameters["uv"].SetValue(uv);
   effect.Parameters["tex"].SetValue(tex);
   effect.CommitChanges();

   foreach (ModelMesh mesh in model.Meshes)
   {
    p.gd.VertexDeclaration = mesh.MeshParts[0].VertexDeclaration;
    p.gd.Vertices[0].SetSource(mesh.VertexBuffer, 0, mesh.MeshParts[0].VertexStride);
    p.gd.Indices = mesh.IndexBuffer;

    p.gd.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, 4, 0, 2);
   }
  }
  public void debugDraw() {}

  public Vector2 AnimCount
  {
   get { return animcount; }
   set { animcount = value; AnimMul = new Vector2(1, 1) / value; }
  }
  public Vector2 AnimMul
  {
   get { return new Vector2(uv.X, uv.Y); }
   set { uv.X = value.X; uv.Y = value.Y; }
  }
  public Vector2 AnimPos
  {
   get { return new Vector2(uv.Z, uv.W); }
   set { uv.Z = value.X; uv.W = value.Y; }
  }
  public void PlayOnce(float dt)
  {
   animtype = ANIMTYPE.once;
   tuv = AnimPos;
   time.Start(p, dt);
  }
  public void PlayLoop(float dt)
  {
   animtype = ANIMTYPE.loop;
   tuv = AnimPos;
   time.Start(p, dt);
  }
  public void PlayLoop(float dt, float ix, float iy)
  {
   animtype = ANIMTYPE.loop;
   tuv = AnimPos;
   time.Start(p, dt);
   AnimPos = new Vector2(ix, iy) / animcount;
  }
  public void Stop()
  {
   animtype = ANIMTYPE._static;
   AnimPos = tuv;
  }


  public void Update(float dt)
  {
   if (animtype == ANIMTYPE._static) return;
   if (animtype == ANIMTYPE.once)
   {
    if (time.End()) { animtype = ANIMTYPE._static; AnimMul = tuv; return; }
    AnimPos = new Vector2(time.getInterval(AnimCount.X), AnimPos.Y);
   }
   if (animtype == ANIMTYPE.loop)
   {
    if (time.End()) time.Restart();
    AnimPos = new Vector2(time.getInterval(AnimCount.X), AnimPos.Y);
   }
  }
 }//class
}//namespace

using Microsoft.Xna.Framework;

namespace DarkSide
{
 public class CAMERA
 {
  public enum STATE
  {
   onPlayer,
   free,
  }
  public STATE state = STATE.onPlayer;
  DEVICE_PACK p = null;
  public Matrix view { get; set; }
  public Matrix proj { get; set; }
  public Matrix viewProj()
  {
   return view * proj;
  }

  private Vector2 pos = Vector2.Zero;
  public Vector2 Position
  {
   get
   {
    return pos;
   }
   set
   {
    if (state == STATE.free)
    {
     eye += new Vector3(value, 0);
     targ += new Vector3(value, 0);
     pos = new Vector2(targ.X, targ.Y);
    }
    else
    {
     eye = teye + new Vector3(value, height);
     targ = ttarg + new Vector3(value, 0);
     pos = value;
    }
   }
  }

  private float height = 10;
  public float Height
  {
   get
   {
    return height;
   }
   set
   {
    height = value;
    eye = new Vector3(eye.X, eye.Y, height);
   }
  }
  public Vector3 teye { get; set; }
  public Vector3 ttarg { get; set; }
  public Vector3 tup { get; set; }
  public Vector3 eye { get; set; }
  public Vector3 targ { get; set; }
  public Vector3 up { get; set; }

  public CAMERA() { eye = new Vector3(0, 0, height); targ = new Vector3(0, 0, 0); up = new Vector3(0, 1, 0); }
  public void Init(DEVICE_PACK dp)
  {
   p = dp;
   view = Matrix.CreateLookAt(eye, targ, up);
   proj = Matrix.CreatePerspectiveFieldOfView(3.14f / 4, p.gd.Viewport.Width / p.gd.Viewport.Height, 1, 1000);
   teye = eye;
   ttarg = targ;
   tup = up;
  }
  public void Update()
  {
   view = Matrix.CreateLookAt(eye, targ, up);
  }

 }//class
}//namespace

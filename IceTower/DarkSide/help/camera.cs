﻿using Microsoft.Xna.Framework;

namespace DarkSide
{
 public class CAMERA
 {
  DEVICE_PACK p = null;
  public Matrix view { get; set; }
  public Matrix proj { get; set; }
  public Matrix viewProj()
  {
   return view*proj;
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
    pos = value;
    eye = teye + new Vector3(value, height);
    targ = ttarg + new Vector3(value, 0);
   }
  }
  public float height { get; set; }
  public Vector3 teye { get; set; }
  public Vector3 ttarg { get; set; }
  public Vector3 tup { get; set; }
  public Vector3 eye { get; set; }
  public Vector3 targ { get; set; }
  public Vector3 up { get; set; }

  public CAMERA() { height = 10; eye = new Vector3(0, 0, height); targ = new Vector3(0, 0, 0); up = new Vector3(0, 1, 0); }
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

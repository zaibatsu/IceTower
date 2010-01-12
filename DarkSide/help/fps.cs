using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DarkSide
{
 class FPS
 {
  float Fps = 0;
  float sec = 0;
  int count = 0;

  public float fps { get { return Fps; }  }
  public void Update(float dt)
  {
   count++;
   sec += dt;
   if (sec >= 1)
   {
    Fps = count / sec;
    count = 0;
    sec = 0;
   }
  }
 }
}

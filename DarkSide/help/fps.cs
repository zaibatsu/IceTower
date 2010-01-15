namespace DarkSide
{
 public class FPS
 {
  private float Fps = 0;
  private float sec = 0;
  private int count = 0;

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

 }//class
}//namespace

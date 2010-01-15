namespace DarkSide
{
 public class TIME
 {
  public float dt = 0;
  public float gametime = 0;
  public void Update(float idt)
  {
   dt = idt;
   if (gametime > 10000) gametime = dt;
   else gametime += dt;
  }
 }

 class TIMER
 {
  DEVICE_PACK p;
  public OBJTYPE type { get; set; }
  float time, startTime, endTime;

  public void Start(DEVICE_PACK ip, float itime)
  {
   p = ip;
   time = itime;
   Restart();
  }
  public void Restart()
  {
   startTime = p.time.gametime;
   endTime = startTime + time;
  }
  public bool End()
  {
   return p.time.gametime > endTime;
  }

  public float getTime()
  {
   return p.time.gametime - startTime;
  }
  public float getInterval(float intervals)
  {
   float s = (getTime() / time) * intervals;
   s = (int)s;

   return s / intervals;
  }

 }//class
}//namespace

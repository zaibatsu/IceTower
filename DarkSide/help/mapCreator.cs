using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using FarseerGames.FarseerPhysics.Collisions;

namespace DarkSide
{
 class mapCreator
 {
  enum FROM
  {
   fromLeft,
   fromRight,
   fromUp,
   fromDown,
  }

  private uint[] data = null;
  private int width, height;
  private Vector2 f = new Vector2(0, 0);
  private FROM from = FROM.fromLeft;
  private List<Vertices> verts = new List<Vertices>();

  private bool checkAndGet(Vector2 v)
  {
   if (checkXY(v)) return getXY(v);
   else return false;
  }
  private bool existXY(Vector2 v, Vertices vert)
  {
   if (!checkXY(v)) return true;
   foreach (Vector2 t in vert)
   {
    if (v == t) return true;
   }
   return false;
  }
  private bool checkXY(Vector2 v)
  {
   if (v.X < 0 || v.X > width - 1 || v.Y < 0 || v.Y > height - 1) return false;
   return true;
  }
  private void setXY(Vector2 v, uint r)
  {
   data[(int)v.Y * width + (int)v.X] = r;
  }
  private void setXY(int x, int y, uint r)
  {
   data[y * width + x] = r;
  }
  private bool getXY(Vector2 v)
  {
   return getXY((int)v.X, (int)v.Y);
  }
  private bool getXY(float x, float y)
  {
   return getXY((int)x, (int)y);
  }
  private bool getXY(int x, int y)
  {
   return (data[y * width + x] & 0xFF000000) > 16777216;
  }
  private bool FindFirst(int ix, int iy)
  {
   for (int y = iy; y < height; ++y)
    for (int x = ix; x < width; ++x)
     if (getXY(x, y))
     {
      f = new Vector2(x, y);
      return true;
     }
   return false;
  }
  private void DeleteVerts(Vertices vi)
  {
   Vector2 v = vi[0];
   List<Vector2> temp = new List<Vector2>();
   while (getXY(v) || temp.Count != 0)
   {
    setXY(v, 0);
    Vector2 v1 = v + new Vector2(0, 1);
    Vector2 v2 = v + new Vector2(0, -1);
    Vector2 v3 = v + new Vector2(1, 0);
    Vector2 v4 = v + new Vector2(-1, 0);
    if (checkXY(v1) && getXY(v1)) { temp.Remove(v1); temp.Add(v1); }
    if (checkXY(v2) && getXY(v2)) { temp.Remove(v2); temp.Add(v2); }
    if (checkXY(v3) && getXY(v3)) { temp.Remove(v3); temp.Add(v3); }
    if (checkXY(v4) && getXY(v4)) { temp.Remove(v4); temp.Add(v4); }

    if (checkXY(v4) && getXY(v4)) { v = v4; temp.Remove(v4); }
    else if (checkXY(v3) && getXY(v3)) { v = v3; temp.Remove(v3); }
    else if (checkXY(v2) && getXY(v2)) { v = v2; temp.Remove(v2); }
    else if (checkXY(v1) && getXY(v1)) { v = v1; temp.Remove(v1); }
    else { if (temp.Count == 0) break; v = temp[0]; temp.RemoveAt(0); }
   }
  }
  private int CountFree(Vector2 p)
  {
   int free = 0;

   if (!checkXY(p)) return 0;
   if (getXY(p.X, p.Y) == false) return 0;

   if ((p.X + 1 == width) || getXY(p.X + 1, p.Y) == false) free += 1;
   if ((p.X - 1 == -1) || getXY(p.X - 1, p.Y) == false) free += 1;
   if ((p.Y + 1 == height) || getXY(p.X, p.Y + 1) == false) free += 1;
   if ((p.Y - 1 == -1) || getXY(p.X, p.Y - 1) == false) free += 1;

   return free;
  }


  private int maxInd(int i1, int i2, int i3)
  {
   if (i1 == Math.Max(Math.Max(i1, i2), i3)) return 1;
   else if (i2 == Math.Max(Math.Max(i1, i2), i3)) return 2;
   else return 3;
  }
  private void NextVector(Vertices v)
  {
   Vector2 up = new Vector2(0, -1) + f;
   Vector2 down = new Vector2(0, 1) + f;
   Vector2 left = new Vector2(-1, 0) + f;
   Vector2 right = new Vector2(1, 0) + f;

   int upf = 0, downf = 0, leftf = 0, rightf = 0;
   upf = CountFree(up);
   downf = CountFree(down);
   leftf = CountFree(left);
   rightf = CountFree(right);

   if (from == FROM.fromLeft)
   {
    if (downf != 0) { f += new Vector2(0, 1); from = FROM.fromUp; return; }
    if (!existXY(down, v) && getXY(down)) { f += new Vector2(0, 1); from = FROM.fromUp; return; }
    if (rightf != 0) { f += new Vector2(1, 0); from = FROM.fromLeft; return; }
    if (!existXY(right, v) && getXY(right)) { f += new Vector2(1, 0); from = FROM.fromLeft; return; }
    if (upf != 0) { f += new Vector2(0, -1); from = FROM.fromDown; return; }
    if (!existXY(up, v) && getXY(up)) { f += new Vector2(0, -1); from = FROM.fromDown; return; }

    if (maxInd(downf, rightf, upf) == 1 && downf != 0) { f += new Vector2(0, 1); from = FROM.fromUp; return; }
    if (maxInd(downf, rightf, upf) == 2 && rightf != 0) { f += new Vector2(1, 0); from = FROM.fromLeft; return; }
    if (maxInd(downf, rightf, upf) == 3 && upf != 0) { f += new Vector2(0, -1); from = FROM.fromDown; return; }

    if (leftf != 0) { f += new Vector2(-1, 0); from = FROM.fromRight; return; }
    if (getXY(left)) { f += new Vector2(-1, 0); from = FROM.fromRight; return; }
   }
   if (from == FROM.fromRight)
   {
    if (upf != 0) { f += new Vector2(0, -1); from = FROM.fromDown; return; }
    if (!existXY(up, v) && getXY(up)) { f += new Vector2(0, -1); from = FROM.fromDown; return; }
    if (leftf != 0) { f += new Vector2(-1, 0); from = FROM.fromRight; return; }
    if (!existXY(left, v) && getXY(left)) { f += new Vector2(-1, 0); from = FROM.fromRight; return; }
    if (downf != 0) { f += new Vector2(0, 1); from = FROM.fromUp; return; }
    if (!existXY(down, v) && getXY(down)) { f += new Vector2(0, 1); from = FROM.fromUp; return; }

    if (maxInd(upf, leftf, downf) == 1 && upf != 0) { f += new Vector2(0, -1); from = FROM.fromDown; return; }
    if (maxInd(upf, leftf, downf) == 2 && leftf != 0) { f += new Vector2(-1, 0); from = FROM.fromRight; return; }
    if (maxInd(upf, leftf, downf) == 3 && downf != 0) { f += new Vector2(0, 1); from = FROM.fromUp; return; }


    if (rightf != 0) { f += new Vector2(1, 0); from = FROM.fromLeft; return; }
    if (getXY(right)) { f += new Vector2(1, 0); from = FROM.fromLeft; return; }
   }
   if (from == FROM.fromUp)
   {
    if (leftf != 0) { f += new Vector2(-1, 0); from = FROM.fromRight; return; }
    if (!existXY(left, v) && getXY(left)) { f += new Vector2(-1, 0); from = FROM.fromRight; return; }
    if (downf != 0) { f += new Vector2(0, 1); from = FROM.fromUp; return; }
    if (!existXY(down, v) && getXY(down)) { f += new Vector2(0, 1); from = FROM.fromUp; return; }
    if (rightf != 0) { f += new Vector2(1, 0); from = FROM.fromLeft; return; }
    if (!existXY(right, v) && getXY(right)) { f += new Vector2(1, 0); from = FROM.fromLeft; return; }

    if (maxInd(leftf, downf, rightf) == 1 && leftf != 0) { f += new Vector2(-1, 0); from = FROM.fromRight; return; }
    if (maxInd(leftf, downf, rightf) == 2 && downf != 0) { f += new Vector2(0, 1); from = FROM.fromUp; return; }
    if (maxInd(leftf, downf, rightf) == 3 && rightf != 0) { f += new Vector2(1, 0); from = FROM.fromLeft; return; }

    if (upf != 0) { f += new Vector2(0, -1); from = FROM.fromDown; return; }
    if (getXY(up)) { f += new Vector2(0, -1); from = FROM.fromDown; return; }
   }
   if (from == FROM.fromDown)
   {
    if (rightf != 0) { f += new Vector2(1, 0); from = FROM.fromLeft; return; }
    if (!existXY(right, v) && getXY(right)) { f += new Vector2(1, 0); from = FROM.fromLeft; return; }
    if (upf != 0) { f += new Vector2(0, -1); from = FROM.fromDown; return; }
    if (!existXY(up, v) && getXY(up)) { f += new Vector2(0, -1); from = FROM.fromDown; return; }
    if (leftf != 0) { f += new Vector2(-1, 0); from = FROM.fromRight; return; }
    if (!existXY(left, v) && getXY(left)) { f += new Vector2(-1, 0); from = FROM.fromRight; return; }

    if (maxInd(rightf, upf, leftf) == 1 && rightf != 0) { f += new Vector2(1, 0); from = FROM.fromLeft; return; }
    if (maxInd(rightf, upf, leftf) == 2 && upf != 0) { f += new Vector2(0, -1); from = FROM.fromDown; return; }
    if (maxInd(rightf, upf, leftf) == 3 && leftf != 0) { f += new Vector2(-1, 0); from = FROM.fromRight; return; }


    if (downf != 0) { f += new Vector2(0, 1); from = FROM.fromUp; return; }
    if (getXY(down)) { f += new Vector2(0, 1); from = FROM.fromUp; return; }
   }
  }
  private Vertices MakePolygon()
  {
   Vertices v = new Vertices();

   do
   {
    v.Add(f);
    NextVector(v);
   } while (f != v[0]);
   v.Add(v[0]);

   return v;
  }

  public List<Vertices> getMap(uint[] idata, int iwidth, int iheight)
  {
   data = idata;
   width = iwidth;
   height = iheight;

   for (; ; )
   {
    if (FindFirst(0, 0))
    {
     Vertices temp = MakePolygon();
     simplify(temp);
     Resize(ref temp);
     DeleteVerts(temp);
     if (temp.Count > 3) verts.Add(temp);
    }
    else return verts;
   }
  }
  private void simplify(Vertices v)
  {
   int j = 0;
   do
   {
    if (v.Count <= 3) break;
    Vector2 v1 = v[j];
    Vector2 v2 = v[j + 1];
    Vector2 v3 = v[j + 2];

    Vector2 k1 = Vector2.Normalize(v3 - v1);
    Vector2 k2 = Vector2.Normalize(v2 - v1);
    if (k1 == k2) v.Remove(v[j + 1]);
    else j += 1;
   }
   while (j + 2 != v.Count - 1);
  }
  private void Resize(ref Vertices v)
  {
   for (int i = 0; i < v.Count; ++i)
   {
    bool upb = !checkAndGet(v[i] + new Vector2(0, -1));
    bool downb = !checkAndGet(v[i] + new Vector2(0, 1));
    bool rightb = !checkAndGet(v[i] + new Vector2(1, 0));
    bool leftb = !checkAndGet(v[i] + new Vector2(-1, 0));

    bool upleftb = !checkAndGet(v[i] + new Vector2(-1, -1));
    bool uprightb = !checkAndGet(v[i] + new Vector2(1, -1));
    bool downrightb = !checkAndGet(v[i] + new Vector2(1, 1));
    bool downleftb = !checkAndGet(v[i] + new Vector2(-1, 1));

    //if (upb && !downb && !leftb && !rightb) v[i] += new Vector2(0, 0.5f);
    if (!upb && downb && !leftb && !rightb) v[i] += new Vector2(0, 1);
    //if (!upb && !downb && leftb && !rightb) v[i] += new Vector2(0, 0);
    if (!upb && !downb && !leftb && rightb) v[i] += new Vector2(1, 0);

    //if (upb && !downb && leftb && !rightb) t += new Vector2(-0.5f, 0.5f);
    if (upb && !downb && !leftb && rightb) v[i] += new Vector2(1, 0);
    if (!upb && downb && leftb && !rightb) v[i] += new Vector2(0, 1);
    if (!upb && downb && !leftb && rightb) v[i] += new Vector2(1, 1);

    if (!upb && !downb && !leftb && !rightb && !upleftb && !uprightb && !downleftb && downrightb) v[i] += new Vector2(1, 1);
    if (!upb && !downb && !leftb && !rightb && !upleftb && !uprightb && downleftb && !downrightb) v[i] += new Vector2(0, 1);
    if (!upb && !downb && !leftb && !rightb && !upleftb && uprightb && !downleftb && !downrightb) v[i] += new Vector2(1, 0);
   }
  }

  public static Vector2 minV(Vertices v)
  {
   Vector2 min = v[0];
   foreach (Vector2 t in v)
   {
    if (t.Length() < min.Length()) min = t;
   }
   return min;
  }
  public static Vector2 maxV(Vertices v)
  {
   Vector2 max = v[0];
   foreach (Vector2 t in v)
   {
    if (t.Length() > max.Length()) max = t;
   }
   return max;
  }

 }//class
}//darkside

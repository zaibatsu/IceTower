using System.Collections.Generic;
using FarseerGames.FarseerPhysics.Dynamics;
using FarseerGames.FarseerPhysics.Collisions;

namespace DarkSide
{
 public enum GEOMTYPE
 {
  box,
  circle,
  ellipse,
  verts,
  none
 }
 interface IPHYS2D
 {
  GEOMTYPE geomType { get; set; }
  List<Body> body { get; set; }
  List<Geom> geom { get; set; }

  void MakeBox(float width, float height, float mass);
  void MakeCircle(float radius, float mass);
  void MakeEllipse(float xradiux, float yradius, float mass);
  bool MakeVerts(float mass);
  void Deleteps();
  void setStatic(bool isStatic);
  void debugVertsDraw(int index);

 }//interface
}//namespace

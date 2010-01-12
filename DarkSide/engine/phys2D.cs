using System.Text;
using System.Collections.Generic;
using FarseerGames.FarseerPhysics;
using FarseerGames.FarseerPhysics.Dynamics;
using FarseerGames.FarseerPhysics.Factories;
using FarseerGames.FarseerPhysics.Collisions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace DarkSide
{
 enum psGeomType
 {
  geom_box,
  geom_circle,
  geom_ellipse,
  geom_verts,
  geom_none
 }

 interface IPHYS2D
 {
  psGeomType geomType { get; set; }
  List<Body> body { get; set; }
  List<Geom> geom { get; set; }

  void MakeBox(float width, float height, float mass);
  void MakeCircle(float radius, float mass);
  void MakeEllipse(float xradiux, float yradius, float mass);
  bool MakeVerts(float mass);
  void Deleteps();
  void setStatic(bool isStatic);
  void debugVertsDraw(int index);
 }
}

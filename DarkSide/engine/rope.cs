namespace DarkSide
{
 /*
class ROPE
{
 List<Body> body = new List<Body>();
 List<Geom> geom = new List<Geom>();
 int count = 4;
 float widht = 0.5f, height = 0.5f;
 float mass = 10.01f;

 MESH2D mesh = new MESH2D();

 public void CreateRope(DEVICE_PACK p)
 {
  mesh.Init(p, "rope", "level", "rope model", new Vector2(widht, height));
  for (int i = 0; i < count; ++i)
  {
   Body bodyT = BodyFactory.Instance.CreateCircleBody(p.ps, widht, mass);
   Geom geomT = GeomFactory.Instance.CreateCircleGeom(p.ps, bodyT, widht, 12);
   bodyT.Position = new Vector2(2, 10 - (float)i * height * 2);

   LinearSpring spr = new LinearSpring();
   //if (i != 0) JointFactory.Instance.CreatePinJoint( bodyT, bodyT.Position, body[i - 1], body[i - 1].Position);
   if (i != 0) spr = SpringFactory.Instance.CreateLinearSpring(p.ps, bodyT, bodyT.Position, body[i - 1], body[i - 1].Position, 100, 10);


   body.Add(bodyT);
   geom.Add(geomT);

  /// if (i != 0) SpringFactory.Instance.CreateLinearSpring(p.ps, body[i], body[i].Position,
  //    body[i - 1], body[i - 1].Position, 50, 1);
  }

 }
 public void Draw(Effect effect)
 {
  for (int i = 0; i < body.Count; ++i)
  {
   mesh.k = new Vector4(body[i].Position.X, body[i].Position.Y, mesh.k.Z, mesh.k.W);
   mesh.Draw(effect);
  }
 }
}//class
  */
}//namespace
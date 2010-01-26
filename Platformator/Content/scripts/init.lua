load_assembly("DarkSide")
load_assembly("FarseerPhysics")

Geom = import_type("FarseerPhysics.Geom")
Body = import_type("FarseerPhysics.Body")

DEVICE_PACK = import_type("DarkSide.DEVICE_PACK")
menup = DEVICE_PACK()
platp = DEVICE_PACK()
p = DEVICE_PACK()

load_assembly("Microsoft.Xna.Framework")
MESH2D = import_type("DarkSide.MESH2D")
Vector2 = import_type("Microsoft.Xna.Framework.Vector2")
OBJECT = import_type("DarkSide.OBJECT")
PLAYER = import_type("DarkSide.PLAYER")
MONSTER = import_type("DarkSide.MONSTER")
p=platp


wh = Vector2(80, 60)
background = MESH2D()
background:Init(p, "background_1", "background", wh, "all")
background.Position = Vector2(0, 0)


wh = Vector2(100, 40)
ground = OBJECT()
ground.debugVerts = true
ground:Init(p,"level", "background", wh, "all")
ground:makeVerts("level", wh)
ground:setFriction(0)


player = PLAYER()
pos = Vector2(0,10)
player:Init(p)
player.Position = pos


wh = Vector2(3, 3)
oops = MESH2D()
oops:Init(p, "oops_1", "oops", wh, "updateOnly")






wh = Vector2(1, 1 )
box0 = OBJECT()
box0.name ="box0"
box0:Init(p, "none", "ui", wh, "all")
box0:makeBox(1, 1, 1)
box0.Position = Vector2(15.5467, 20.45019 )
box0.Rotation = 5.812568E-05
box0:setFriction(1)

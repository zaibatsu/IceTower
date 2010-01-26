p=platp

wh = Vector2(80, 60)
background = MESH2D()
background:Init(p, "background_1", "background", wh, "all")
background.Position = Vector2(0, 0)


wh = Vector2(100, 40)
ground = OBJECT()
ground.debugVerts = true
ground:Init(p, "level_1", "level", wh, "all")
ground:makeVerts(1000)
ground:setFriction(0)


wh = Vector2(2, 2)
barrel = OBJECT()
barrel:Init(p, "barrel", "level", wh, "all")
barrel:makeCircle(1, 10)
barrel.Position = Vector2(0, 0)
barrel:setFriction(2)


wh = Vector2(2, 2)
barrel2 = OBJECT()
barrel2:Init(p, "barrel", "level", wh, "all")
barrel2:makeCircle(1, 10)
barrel2.Position = Vector2(0, 6)
barrel2:setFriction(2)


player = PLAYER()
player:Init(p)
pos = Vector2(0,50)
player.Position = pos


wh = Vector2(2, 2)
barrel3 = OBJECT()
barrel3:Init(p, "barrel", "level", wh, "all")
barrel3:MakeCircle(1, 10)
barrel3.Position = Vector2(0, 12)
barrel3:setFriction(2)


wh = Vector2(3, 3)
oops = MESH2D()
oops:Init(p, "oops_1", "oops", wh, "updateOnly")



player = PLAYER()
player:Init(p)
pos = Vector2(0,50)
player.Position = pos
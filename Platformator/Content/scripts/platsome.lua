p=platp


wh = Vector2(80, 60)
background = MESH2D()
background:Init(p, "background_1", "background", wh, "all")
background.Position = Vector2(0, 0)


wh = Vector2(100, 40)
ground = OBJECT()
ground.debugVerts = true
ground:Init(p,"908785688", "background", wh, "all")
ground:MakeVerts(1000)
ground:setFriction(0)


player = PLAYER()
pos = Vector2(0,10)
player:Init(p)
player.Position = pos


wh = Vector2(3, 3)
oops = MESH2D()
oops:Init(p, "oops_1", "oops", wh, "updateOnly")
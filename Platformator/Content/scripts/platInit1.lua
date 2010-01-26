p=platp

wh = Vector2(80, 60)
background = MESH2D()
background:Init(p, "background_1", "background", wh, "all")
background.Position = Vector2(0, 0)


wh = Vector2(100, 40)
ground = OBJECT()
ground.debugVerts = true
ground:Init(p, "level_1", "plat", wh, "all")
ground:makeVerts("level_1", wh)
ground:setFriction(0)



wh = Vector2(3, 3)
oops = MESH2D()
oops:Init(p, "oops_1", "plat", wh, "updateOnly")


player = PLAYER()
player:Init(p)
pos = Vector2(0,25)
player.Position = pos
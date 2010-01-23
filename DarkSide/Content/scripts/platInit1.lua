p=platp

wh = Vector2(80, 60)
background = MESH2D()
background:Init(p, "background_1", "background", wh, "all")
background.Position = Vector2(0, 0)


wh = Vector2(100, 40)
ground = OBJECT()
ground.debugVerts = true
ground:Init(p, "level_1", "level", wh, "all")
ground:MakeVerts(1000)
ground:setFriction(0)


wh = Vector2(2, 2)
ball = OBJECT()
ball:Init(p, "ball", "level", wh, "all")
ball:MakeCircle(wh.X/2, 10)
ball.Position = Vector2(1, 20)
ball:setFriction(2)



wh = Vector2(3, 3)
oops = MESH2D()
oops:Init(p, "oops_1", "oops", wh, "updateOnly")



player = PLAYER()
player:Init(p)
pos = Vector2(0,30)
player.Position = pos
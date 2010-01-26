p=platp


wh = Vector2(80, 60)
background = MESH2D()
background:Init(p, "background_1", "background", wh, "all")
background.Position = Vector2(0, 0)


wh = Vector2(100, 40)
ground = OBJECT()
ground.debugVerts = true
ground:Init(p,"level_1", "background", wh, "all")
ground:makeVerts("level_1", wh)
ground:setFriction(0)


player = PLAYER()
pos = Vector2(0,10)
player:Init(p)
player.Position = pos


wh = Vector2(3, 3)
oops = MESH2D()
oops:Init(p, "oops_1", "oops", wh, "updateOnly")






wh = Vector2(3, 1 )
box0 = OBJECT()
box0.name ="box0"
box0:Init(p, "none", "ui", wh, "all")
box0:makeBox(3, 1, 1)
box0.Position = Vector2(3.125566, 20.45547 )
box0.Rotation = 3.139914
box0:setFriction(1)



wh = Vector2(1, 1 )
box1 = OBJECT()
box1.name ="box1"
box1:Init(p, "none", "ui", wh, "all")
box1:makeBox(1, 1, 1)
box1.Position = Vector2(1.093364, 20.49999 )
box1.Rotation = 1.570725
box1:setFriction(1)



wh = Vector2(0, 0 )
ellipse0 = OBJECT()
ellipse0.name ="ellipse0"
ellipse0:Init(p, "none", "ui", wh, "all")
ellipse0:makeEllipse(1, 1, 1)
ellipse0.Position = Vector2(3.064976, 21.92849 )
ellipse0.Rotation = 0.01192706
ellipse0:setFriction(1)



wh = Vector2(0, 0 )
circle0 = OBJECT()
circle0.name ="circle0"
circle0:Init(p, "none", "ui", wh, "all")
circle0:makeCircle(1, 1)
circle0.Position = Vector2(1.123637, 22.36756 )
circle0:setFriction(1)

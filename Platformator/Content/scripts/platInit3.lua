p=platp


wh = Vector2(80, 60)
background = MESH2D()
background:Init(p,"level", "background", wh, "all")
background.Position = Vector2(0, 0)


player = PLAYER()
pos = Vector2(0,50)
player:Init(p)
player.Position = pos

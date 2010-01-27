p=menup


wh = Vector2(640,480)
menubackground = MESH2D()
menubackground:Init(p, "menu", "ui", wh, "all");
menubackground.UIPosition =  Vector2(320, 240);


wh = Vector2(200,100)
new_game = MESH2D()
new_game:Init(p, "new_game", "ui", wh, "all")
new_game.UIPosition =  Vector2(320, 60 + 360)
new_game.AnimCount =  Vector2(5, 3);
new_game:PlayLoop(1, 0, 1);


save_load = MESH2D()
save_load:Init(p, "save_load", "ui", wh, "all");
save_load.UIPosition =  Vector2(320, 60+240);
save_load.AnimCount =  Vector2(5, 3);


settings = MESH2D()
settings:Init(p, "settings", "ui", wh, "all");
settings.UIPosition =  Vector2(320, 60 + 120);
settings.AnimCount =  Vector2(5, 3);


quit = MESH2D()
quit:Init(p, "quit", "ui", wh, "all");
quit.UIPosition =  Vector2(320, 60);
quit.AnimCount =  Vector2(5, 3);
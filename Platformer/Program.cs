using Raylib_cs;

Raylib.InitWindow(800, 700, "Platform Ghost");
Raylib.SetTargetFPS(60);
float speed = 5.5f;

//Texture
Texture2D avatarImage = Raylib.LoadTexture("images/PlayerGhost.png");
Texture2D enemyImage = Raylib.LoadTexture("");
Texture2D menu = Raylib.LoadTexture("images/Graveyard_menu.png");
Texture2D ammoBox = Raylib.LoadTexture("images/AmmoBox.png");

//Hitboxes
Rectangle playerRect = new Rectangle(0, 0, avatarImage.width, avatarImage.height);
Rectangle trapRect = new Rectangle(700, 500, 64, 64);
Rectangle enemyRect = new Rectangle(70, 70, enemyImage.width, enemyImage.height);

string currentScene = "start"; //Start, game, end

//Game
while (Raylib.WindowShouldClose() == false)
{
    if (currentScene == "Game")
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            playerRect.x += speed;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            playerRect.x -= speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
        {
            playerRect.y -= speed;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
        {
            playerRect.y += speed;
        }
    }
    else if (currentScene == "start")
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
        {
            currentScene = "game";
        }
    }
}

//Grafik
Raylib.BeginDrawing();
Raylib.ClearBackground(Color.WHITE);

if (currentScene == "game")
{
    // Raylib.DrawTexture(//backgorund,
    //     0,
    //     0,
    //     Color.WHITE);

    Raylib.DrawTexture(avatarImage,
      (int)playerRect.x,
      (int)playerRect.y,
      Color.WHITE);
    Raylib.DrawRectangleRec(trapRect, Color.RED);
}
else if (currentScene == "start")
{
    Raylib.DrawTexture(menu,
    0,
    0,
    Color.WHITE);
    Raylib.DrawText("Press [ENTER] to start", 75, 500, 30, Color.WHITE);

}
else if (currentScene == "end")
{
    Raylib.DrawText("Game over", 10, 10, 64, Color.RED);
}

Raylib.EndDrawing();
using Raylib_cs;

Raylib.InitWindow(800, 700, "Platform Ghost");
Raylib.SetTargetFPS(60);

string currentScene = "start"; //Start, game, end

float speed = 5.5f;

Texture2D avatarImage = Raylib.LoadTexture("PlayerGhost.png");
Texture2D enemyImage = Raylib.LoadTexture("");
Texture2D menu = Raylib.LoadTexture("Graveyard_menu.png");

Rectangle playerRect = new Rectangle(0, 0, avatarImage.width, avatarImage.height);
Rectangle trapRect = new Rectangle(700, 500, 64, 64);

Rectangle enemyRect = new Rectangle(70, 70, enemyImage.width, enemyImage.height);

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

}
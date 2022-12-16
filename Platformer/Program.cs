using Raylib_cs;
Random generator = new Random();

Raylib.InitWindow(800, 600, "Platform Ghost");
Raylib.SetTargetFPS(60);

//background
Texture2D menuImage = Raylib.LoadTexture("images/Graveyard_menu.png");


//Images
//player
Texture2D playerImage = Raylib.LoadTexture("images/PlayerGhost.png");
Texture2D playerImage1 = Raylib.LoadTexture("images/PlayerGhostLeft.png");
//enemy
Texture2D enemyImage = Raylib.LoadTexture("images/DuckWithGun.png");
Texture2D enemyImageLeft = Raylib.LoadTexture("images/DuckWithGunLeft.png");
//props
Texture2D ammoboxImage = Raylib.LoadTexture("images/AmmoBox.png");
Texture2D healthBoxImage = Raylib.LoadTexture("images/HealthBox.png");
Texture2D doorImage = Raylib.LoadTexture("images/door.png");
Texture2D oldMan = Raylib.LoadTexture("images/oldMan.png");
Texture2D nerfDart = Raylib.LoadTexture("images/Nerfdart.png");



//Hitbox
Rectangle playerRect = new Rectangle(600, 0, playerImage.width, playerImage.height);
//Duck enemy right and left
Rectangle enemyRect = new Rectangle(0, 0, enemyImage.width, enemyImage.height);
//props 
Rectangle ammoboxRect = new Rectangle(0, 0, ammoboxImage.width, ammoboxImage.height);
Rectangle healthboxRect = new Rectangle(0, 0, healthBoxImage.width, healthBoxImage.height);
Rectangle doorRect = new Rectangle(0, 0, doorImage.width, doorImage.height);
Rectangle oldManRect = new Rectangle(600, 400, oldMan.width + 70, oldMan.height);
Rectangle trapRect = new Rectangle(700, 500, 64, 64);
Rectangle floorRect = new Rectangle(600, 500, 64, 32);
Rectangle shootRect = new Rectangle(0, 0, nerfDart.width, nerfDart.height);


//Lägg till skot 
//Rectangle ShootRect = new Rectangle(enemy.x , enemy.y, 4, 2);

int playerHealth = 50;
int duckHealth = 30;

//float shootSpeedRight = 10f;
//float shootSpeedLeft =-10f;
float speed = 5f;

float velocity = -64f;
float g = 2;

// verticalVelocity
// gravity
// playerRect



bool directionRight = true;

string currentScene = "start"; //Start, game, end

while (Raylib.WindowShouldClose() == false)
{

    // Logik

    if (currentScene == "game")
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            playerRect.x += speed;
            directionRight = true;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            playerRect.x -= speed;
            directionRight = false;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
        {
            playerRect.y -= speed;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
        {
            playerRect.y += speed;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
        {
            playerRect.y -= speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_R))
        {
            currentScene = ("start");
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_F))
        {
            //skott åt hållet man tittar åt
            if (directionRight == true)
            {

            }
            else if (directionRight == false)
            {

            }
        }

        while (playerRect.y >= velocity)
        {
            velocity += g;
        }
        // 1. applicera gravitation på velocity (velocity += grav)
        // 2. applicera velity på rect.y-värdet





        if (Raylib.CheckCollisionRecs(playerRect, trapRect))
        {
            currentScene = "end";
        }

        if (Raylib.CheckCollisionRecs(playerRect, shootRect))
        {
            playerHealth -= 10;
            if (playerHealth <= 0)
            {
                currentScene = "end";
            }
        }

        if (Raylib.CheckCollisionRecs(enemyRect, shootRect))
        {
            duckHealth -= 10;
            if (duckHealth <= 0)
            {
                //remove duck 
            }
        }

        if (Raylib.CheckCollisionRecs(playerRect, floorRect))
        {

        }

    }
    else if (currentScene == "start")
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
        {
            currentScene = "game";
        }
    }

    // Grafik
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);

    if (directionRight == true)
    {
        Raylib.DrawTexture(playerImage,
          (int)playerRect.x,
          (int)playerRect.y,
          Color.WHITE);
    }
    else if (directionRight == false)
    {
        Raylib.DrawTexture(playerImage1,
          (int)playerRect.x,
          (int)playerRect.y,
          Color.WHITE);
    }

    if (currentScene == "game")
    {
        Raylib.DrawTexture(menuImage,
            0,
            0,
            Color.WHITE);

        Raylib.DrawTexture(playerImage,
          (int)playerRect.x,
          (int)playerRect.y,
          Color.WHITE);
        Raylib.DrawRectangleRec(trapRect, Color.RED);
        Raylib.DrawRectangleRec(floorRect, Color.WHITE);
        Raylib.DrawTexture(oldMan,
          600,
          400,
          Color.WHITE);
        if (Raylib.CheckCollisionRecs(playerRect, oldManRect))
        {
            Raylib.DrawText("[Press P to speak]",
            500,
            300, 30,
            Color.WHITE);
            if (Raylib.IsKeyDown(KeyboardKey.KEY_P))
            {
                //ljudfil
            }
        }
        Raylib.DrawText($"Health = {playerHealth}", 0, 0, 30, Color.WHITE);
    }
    else if (currentScene == "start")
    {
        Raylib.DrawTexture(menuImage,
            0,
            0,
            Color.WHITE);
        Raylib.DrawText("Press [ENTER] to start", 75, 500, 30, Color.WHITE);

    }
    else if (currentScene == "end")
    {
        Raylib.DrawText("Game over", 10, 10, 64, Color.RED);
        Raylib.DrawText("Press R to restart", 200, 200, 64, Color.BLUE);
        if (Raylib.IsKeyDown(KeyboardKey.KEY_R))
        {
            currentScene = ("game");
            playerRect.x = 20;
            playerRect.y = 40;
        }
    }

    Raylib.EndDrawing();
}
using System.Data;
using System.Numerics;
using Raylib_cs;

namespace HelloWorld;

class Program
{
        enum Weather{
            Sunny,
            Cloudy, 
            Rainy
        }
    public static void Main()
    {
        int windowWidth = 800;
        int windowHeight = 480;
        Raylib.InitWindow(windowWidth, windowHeight, "Hello World");

        Grass[,] lawnGrid = new Grass[18,15];
        for (int i = 0; i < 18; i++){ //700 x 400 35 per row, 20 per col?
            for (int e = 0; e < 15; e++){
                lawnGrid[i,e] = new Grass(110 + (i * 40) + Raylib.GetRandomValue(-3, 3), 110 + e * 30 + Raylib.GetRandomValue(-3, 3));
            }
        }

        Drawable d = new Drawable();
        Animatable a = new Animatable();
        d.destinationRectangle = new Rectangle(100, 100, 64, 64);
        a.destinationRectangle = new Rectangle(100, 200, 64, 64);

        float grassFlowTimer = 0.0f;
        double windModifier = 0.5f;
        int weatherID = 0;
        bool isDay = true;
        Shader cloudShader = Raylib.LoadShader("", "cloudShader.frag");
        Image cloudIMG = Raylib.GenImagePerlinNoise((windowWidth - 100) * 2, (windowHeight - 80) * 2, 0, 0, 2);
        Texture2D cloudTexture = Raylib.LoadTextureFromImage(cloudIMG);
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);
            
            Raylib.DrawRectangle(100, 80, windowWidth - 100, windowHeight - 80, new Color(110, 160, 40, 255));

            grassFlowTimer += (float)(Raylib.GetFrameTime() * windModifier);
            foreach (Grass g in lawnGrid){
                if (g != null) g.drawGrass((float)(Raylib.GetFrameTime() * windModifier), windModifier);
            }

            windModifier += Raylib.GetMouseWheelMove() * 0.1;
            windModifier = Math.Clamp(windModifier, 0.2, 2.0);
            if (Raylib.IsKeyPressed(KeyboardKey.One)) weatherID = (weatherID + 1) % 3;
            if (Raylib.IsKeyPressed(KeyboardKey.Two)) isDay = !isDay;


            Raylib.DrawRectangle(0, 0, windowWidth, 80, new Color(100, 100, 120, 255));
            Raylib.DrawRectangle(0, 80, 100, windowHeight - 80, new Color(160, 150, 160, 255));

            /*if (weatherID >= 1) {
                Raylib.SetShaderValue(cloudShader, 0, grassFlowTimer, ShaderUniformDataType.Float);
                Raylib.BeginShaderMode(cloudShader);
                Raylib.DrawTextureRec(cloudTexture, new Rectangle(0, 0, windowWidth - 100, windowHeight - 80), new Vector2(100, 80), new Color(255, 255, 255, 255));
                Raylib.EndShaderMode();
                //Raylib.DrawRectangle(100, 80, windowWidth - 100, windowHeight - 80, new Color(20, 20, 30, 100));
            }*/
            if (!isDay) {
                Raylib.DrawRectangle(100, 80, windowWidth - 100, windowHeight - 80, new Color(0, 10, 60, 80));
            }

            Raylib.DrawText("FPS: " + Raylib.GetFPS(), 12, 12, 20, Color.Black);
            Raylib.DrawText("Wind Modifier: " + windModifier, 12, 32, 20, Color.Black);
            Raylib.DrawText("[1] Weather: " + (Weather)weatherID, 230, 12, 20, Color.Black);
            Raylib.DrawText("[2] isDay: " + isDay, 230, 32, 20, Color.Black);
            //Raylib.DrawText("Wind Timer: " + grassFlowTimer, 12, 52, 20, Color.Black);

            a.draw(Raylib.GetFrameTime());
            a.drawOrigin();
            d.draw();
            d.drawOrigin();

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}


using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using Raylib_cs;

class Grass{
    Texture2D grass = Raylib.LoadTexture("resources\\grassBlades.png");
    int posX;
    int posY;
    float flowRot = 0.0f;
    public Grass(){
        posX = 0;
        posY = 0;
    }
    public Grass(int x, int y){
        posX = x;
        posY = y;
    }

    public void drawGrass(float deltaTime, double windModifier){
        flowRot += deltaTime;
        float tempRot = flowRot + 0.6f;
        float tempX = posX;
        float tempY = posY;
        
        if (windModifier <= 0.0f) {
            tempX = -posX;
            tempY = -posY;
            //grassHighlight = -grassHighlight;
        }
        int grassHighlight = (int)(Math.Cos(((tempRot) - tempX / (500.0) - tempY / (1500.0)) * 5) * 25);
        double grassRotation = (Math.Cos((flowRot - tempX / (500.0) - tempY / (1500.0)) * 5));
        Color c = new Color(230 + grassHighlight, 230 + grassHighlight, 230 + grassHighlight, 255);
        //(int)(Math.Cos((flowRot - posX / 500.0 - posY / 2000.0) * 5) * 5)
        Raylib.DrawTexturePro(grass, new Rectangle(0, 0, 32, 32), new Rectangle(posX, posY, 64, 64), new System.Numerics.Vector2(32, 64), 3 - (int)(grassRotation * 5), c);
        Raylib.DrawTexturePro(grass, new Rectangle(32, 0, 32, 32), new Rectangle(posX, posY, 64, 64), new System.Numerics.Vector2(32, 64), 6 - (int)(grassRotation * 8), c);
        Raylib.DrawTexturePro(grass, new Rectangle(64, 0, 32, 32), new Rectangle(posX, posY, 64, 64), new System.Numerics.Vector2(32, 64), 6 - (int)(grassRotation * 8), c);
        Raylib.DrawCircle(posX, posY, 4, Color.Red);
    }
}
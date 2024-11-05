using System.Numerics;
using Raylib_cs;

class Drawable{
    public Texture2D texture;
    public Rectangle sourceRectangle;
    public Rectangle destinationRectangle;
    public Vector2 origin;
    public float rotation;
    public Color tint;

    public Drawable(){
        texture = Raylib.LoadTexture("""resources\nullSprite.png""");
        sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        destinationRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        rotation = 0.0f;
        origin = new Vector2(0, 0);
        tint = Color.White;
    }

    public Drawable(Texture2D texture, Vector2 position, Vector2 origin, float rotation, Color tint){
        this.texture = texture;
        this.sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        this.destinationRectangle = new Rectangle(position.X, position.Y, texture.Width, texture.Height);
        this.origin = origin;
        this.rotation = rotation;
        this.tint = tint;
    }

    public Drawable(Texture2D texture, Rectangle sourceRect, Rectangle destRect, Vector2 origin, float rotation, Color tint){
        this.texture = texture;
        this.sourceRectangle = sourceRect;
        this.destinationRectangle = destRect;
        this.origin = origin;
        this.rotation = rotation;
        this.tint = tint;
    }
    public void draw(){
        Raylib.DrawTexturePro(texture, sourceRectangle, destinationRectangle, origin, rotation, tint);
    }

    public void drawOrigin(){
        Raylib.DrawCircle((int)destinationRectangle.X, (int)destinationRectangle.Y, 5, Color.Red);
    }
}
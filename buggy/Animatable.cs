using Raylib_cs;

class Animatable : Drawable{
    public Rectangle[,] frames = new Rectangle[1,2];
    public float frameTime = 1.0f;
    public float currentTime = 0;
    public int currentAnimation;
    public int currentFrame;


    public Animatable() : base(){
        frames[0, 0] = sourceRectangle;
        frames[0, 1] = new Rectangle(texture.Width, 0, -texture.Width, texture.Height);
    }
    public void draw(float deltaTime){
        currentTime += deltaTime;
        if (currentTime >= frameTime){
            currentTime -= frameTime;
            currentFrame = (currentFrame + 1) % frames.Length;
        }
        Raylib.DrawTexturePro(texture, frames[0, currentFrame], destinationRectangle, origin, rotation, tint);
    }
}
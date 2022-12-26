namespace PlatformerGame.Engine;

public class Impulse
{
    public int X { get; set; }
    public int Y { get; set; }
    public int StartFrame { get; set; }
    public int NumFrames { get; set; }

    public Impulse()
    {
        
    }

    public Impulse(int x, int y, int startFrame, int numFrames)
    {
        X = x;
        Y = y;
        StartFrame = startFrame;
        NumFrames = numFrames;
    }

    public bool CanRemove(int frame)
    {
        return frame >= StartFrame + NumFrames;
    }
}
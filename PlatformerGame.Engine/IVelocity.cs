using PlatformerGame.Engine.Game.Actors;

namespace PlatformerGame.Engine;

public interface IVelocity
{
    int DeltaX { get; set; }
    int DeltaY { get; set; }
    int StartFrameNumber { get; set; }
    int NumFramesUntilEnd { get; set; }
    void Apply(IActor actor, EngineStateUpdate update);
    void ApplyImpulse(Impulse imp);
    string ToString();
}
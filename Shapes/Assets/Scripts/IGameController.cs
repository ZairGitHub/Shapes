public interface IGameController
{
    bool IsInDebugMode { get; }
    bool IsRunning { get; }
    ScoreController ScoreController { get; }

    void StopRunning();
}
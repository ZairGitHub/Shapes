public interface IGameController
{
    bool IsInDebugMode { get; }

    bool IsRunning { get; }

    void StopRunning();
}
namespace Experia.Framework
{
    public enum EngineFlags { Debug, MultiCore, Networking }
    public enum ComponentState { Paused, Running, Loading, Initializing, Disposing }
    public enum GameState { InFullScreenMenu, InWindowedMenu, LoadingAssets, AsyncLoadingAssets, PlayingGame, PausedGame, SavingGame, CallingExit }
    public enum AntiAliasingFlags { MSAA, FXAA, SSAA }
    public enum VerticleSyncFlags { LockedVsync, UnlockedVsync }
}
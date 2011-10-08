namespace Experia.Framework
{
    public enum ComponentState { Paused, Running, Loading, Initializing, Disposing }
    /// <summary>Controls deeper components that can only be disabled or enabled on startup</summary>
    public enum EngineFlags { Debug, MultiCore, Networking }
}
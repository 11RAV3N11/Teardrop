namespace Experia.Framework
{
    /// <summary>Controls the state of the component</summary>
    public enum ComponentState { Paused, Running, Loading, Initializing, Disposing }
    /// <summary>Controls deeper components that can only be disabled or enabled on startup</summary>
    public enum EngineFlags { Debug, MultiCore, Networking }
    public enum UIState { Active, Inactive } 
}
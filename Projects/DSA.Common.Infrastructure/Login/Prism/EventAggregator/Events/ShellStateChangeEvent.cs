using Microsoft.Practices.Prism.Events;

namespace DSA.Common.Infrastructure.Prism.EventAggregator.Events
{
    /// <summary>
    /// The event for changing screens in prism.
    /// </summary>
    public class ShellStateChangeEvent : CompositePresentationEvent<ShellState> { }

    /// <summary>
    /// The ShellState for screens.
    /// </summary>
    public enum ShellState
    {
        Mainpage,
        Login,
        Settings,
        Patient,
        SystemSettings
    }
}

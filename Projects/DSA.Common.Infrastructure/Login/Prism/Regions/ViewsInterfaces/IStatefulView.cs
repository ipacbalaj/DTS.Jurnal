using DSA.Common.Infrastructure.Prism.EventAggregator.Events;

namespace DSA.Common.Infrastructure.Prism.Regions.ViewsInterfaces
{
    /// <summary>
    /// This interface will be implemented by all screens having <see cref="ShellState"/>
    /// </summary>
    public interface IStatefulView
    {
        ShellState RegionToken { get; set; }
    }
}

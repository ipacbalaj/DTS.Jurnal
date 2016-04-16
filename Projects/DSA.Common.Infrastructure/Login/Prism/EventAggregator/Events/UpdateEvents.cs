using Microsoft.Practices.Prism.Events;

namespace DSA.Common.Infrastructure.Prism.EventAggregator.Events
{
    public class UpdateSchedulerEvent : CompositePresentationEvent<object> { }
    public class UpdateDentalRecordsEvent : CompositePresentationEvent<object> { }
    public class UpdateFiltersEvent : CompositePresentationEvent<object> { }
    public class UpdateSettingsEvent : CompositePresentationEvent<object> { }
    public class UpdatePersonalInfo : CompositePresentationEvent<object> { }
    public class UpdateReportsEvent : CompositePresentationEvent<object> { }
    public class UpdatePersonalInfoEvent : CompositePresentationEvent<object> { }
    public class UpdateFinancialEvent : CompositePresentationEvent<object> { }
    public class DataLoadedEvent : CompositePresentationEvent<object> { }
    public class UserNameChangedEvent : CompositePresentationEvent<string> { }
}

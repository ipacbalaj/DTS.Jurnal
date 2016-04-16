using System;
using Microsoft.Practices.Prism.Events;

namespace DSA.Common.Infrastructure.Prism.EventAggregator.Events
{
    public class FiltersAppliedEvent : CompositePresentationEvent<object> { }
    public class ReportsInterventionsEvent : CompositePresentationEvent<object> { }
    public class PatientSelectedEvent : CompositePresentationEvent<object> { }
    public class PatientNameChangedEvent : CompositePresentationEvent<object> { }
    public class PatientAddedEvent : CompositePresentationEvent<object> { }
    public class PatientDoubleClickedEvent : CompositePresentationEvent<object> { }
    public class InterventionPaymentChangedEvent : CompositePresentationEvent<object> { }
    public class IntervalSetEvent : CompositePresentationEvent<bool> { }
    public class UserLoginEvent : CompositePresentationEvent<string> { }

}

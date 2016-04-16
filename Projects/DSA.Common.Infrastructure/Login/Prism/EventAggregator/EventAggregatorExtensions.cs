using System;
using Microsoft.Practices.Prism.Events;

namespace DSA.Common.Infrastructure.Prism.EventAggregator
{
    /// <summary>
    /// The extention methods for event aggragator.
    /// </summary>
    public static class EventAggregatorExtensions
    {
        /// <summary>
        /// Subscribes the specified event ag.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="eventAg">The event ag.</param>
        /// <param name="action">The action.</param>
        public static void Subscribe<T>(this IEventAggregator eventAg, Action<T> action) where T : CompositePresentationEvent<T>, new()
        {
            eventAg.GetEvent<T>().Subscribe(action);
        }

        /// <summary>
        /// Publishes the specified event ag.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="eventAg">The event ag.</param>
        /// <param name="token">The token.</param>
        public static void Publish<T>(this IEventAggregator eventAg, T token) where T : CompositePresentationEvent<T>, new()
        {
            eventAg.GetEvent<T>().Publish(token);
        }
    }
}

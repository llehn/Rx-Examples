using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Demo4
{
    public class EventHub 
    {
        private readonly Subject<object> subject = new Subject<object>();

        public void PublishEvent(object @event) => 
            subject.OnNext(@event);
        
        public IObservable<T> GetObservable<T>() => 
            subject.OfType<T>().ObserveOn(ThreadPoolScheduler.Instance)
                .AsObservable();
    }
}
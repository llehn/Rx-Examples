using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace Demo5
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Timer(500);
            
            timer.Start();
            
//            var obs = Observable
//                .FromEventPattern<ElapsedEventHandler, ElapsedEventArgs>(
//                    add => timer.Elapsed += add,
//                    remove => timer.Elapsed -= remove)
//                .Select(el => el.EventArgs.SignalTime)
//                .Take(10)
//                .Select(time => time.ToString("O"));
//            
            
            var obs = Observable.Interval(TimeSpan.FromMilliseconds(500)).Publish();
            
            obs.Connect();
            Task.Delay(2000).Wait();
            obs.Subscribe(el => Console.WriteLine($"first {el}"));
            
            obs.Subscribe(el => Console.WriteLine($"second {el}"));
            
            Console.ReadKey();
        }
    }
}
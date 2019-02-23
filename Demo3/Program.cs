using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace Demo3
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Timer(500);
            
            timer.Start();
            
            var obs = Observable
                .FromEventPattern<ElapsedEventHandler, ElapsedEventArgs>(
                    add => timer.Elapsed += add,
                    remove => timer.Elapsed -= remove)
                .Select(el => el.EventArgs.SignalTime)
                .Take(1).Wait();

            Console.WriteLine(obs);
            
//            var subscription = obs.ObserveOn(ThreadPoolScheduler.Instance)
//                .Subscribe(el => Console.WriteLine(el.ToString("O")));

            Console.WriteLine("press to dispose");
            Console.ReadKey();
//            subscription.Dispose();
            
            Console.WriteLine("press to exit");
            Console.ReadKey();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Newtonsoft.Json;

namespace Demo7
{
    class Program
    {
        static void Main(string[] args)
        {
//            Distinct();
//            Throttle();
//            Buffer();
//            Window();
//            Scan();
//            GroupBy();
//            WithLatestFrom();
//            Switch();
            SelectMany();
        }

        private static void SelectMany()
        {
            int j = 0;
            Observable.Range(1, 10)
                .SelectMany(i =>
                {
                    var k = j++;
                    return Observable.Range(1, i).Select(el => $"str: {k} {el}");
                })
                .Subscribe(Console.WriteLine);
        }

        private static void Switch()
        {
            var subject = new Subject<char>();
            
            subject.GroupBy(s => s)
                .Switch()
                .Subscribe(el => Console.WriteLine($"\nOUT: {el}"));
            
            while (true)
                subject.OnNext(Console.ReadKey().KeyChar);
            
        }
        
        private static void WithLatestFrom()
        {
            Observable.Interval(TimeSpan.FromMilliseconds(500))
                .CombineLatest(Observable.Range(30, 10),
                    ((l, i) => $"{i}+{l}"))
                .Subscribe(Console.WriteLine);
            
            Console.ReadKey();
        }

        private static void GroupBy()
        {
            var o = new List<object>
            {
                4, 5, "OMG", DateTime.Now, "LOLZ", 4.5
            }.ToObservable();
            
            o.GroupBy(el => el.GetType())
                .Subscribe(inner => 
                    inner.Subscribe(innerElement => 
                        Console.WriteLine($"{inner.Key}: {innerElement}")));
        }

        private static void Scan()
        {
            var subject = new Subject<char>();
            
            subject.Scan("", (el1, el2) => $"{el1}{el2}").Throttle(TimeSpan.FromMilliseconds(500)).Subscribe(el => Console.WriteLine($"\nOUT: {el}"));
            
            while (true)
                subject.OnNext(Console.ReadKey().KeyChar);
        }

        private static void Window()
        {
            var obs = Observable.Interval(TimeSpan.FromMilliseconds(500));
            
            obs.Window(3, 1)
                
                .Subscribe(inner => inner.Subscribe(el => Console.WriteLine(JsonConvert.SerializeObject(el))));
            
            Console.ReadKey();
        }

        private static void Buffer()
        {
            var obs = Observable.Interval(TimeSpan.FromMilliseconds(500));
            
            obs.Take(3).Buffer(3, 1)
                
                .Subscribe(el => Console.WriteLine(JsonConvert.SerializeObject(el)),
                    () => Console.WriteLine("DONE!"));
            
            Console.ReadKey();
        }
        
        private static void Throttle()
        {
            var subject = new Subject<char>();
            
            subject.Throttle(TimeSpan.FromMilliseconds(400)).Subscribe(el => Console.WriteLine($"\nOUT: {el}"));
            
            while (true)
                subject.OnNext(Console.ReadKey().KeyChar);
        }

        private static void Distinct()
        {
            var obs = new [] {2, 4, 6, 7, 7, 8, 5, 4, 9 }.ToObservable();
            
            obs.DistinctUntilChanged().Subscribe(Console.WriteLine);
        }
    }
}
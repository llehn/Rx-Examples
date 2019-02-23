using System;
using System.Reactive.Subjects;

namespace Demo4
{
    class Program
    {
        static void Main(string[] args)
        {
            var subject = new ReplaySubject<string>("s");
            
            subject.Subscribe(el => Console.WriteLine($"Ausgabe {el}"));

            subject.OnNext("sd");
            subject.Subscribe(el => Console.WriteLine($"Ausgabe 2 {el}"));
            subject.OnNext("sd2");
            subject.OnNext("sd3");
            
        }
    }
}
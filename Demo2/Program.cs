using System;
using System.Linq;
using System.Reactive.Linq;

namespace Demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            var o = Observable.Range(1, 10);
            
            o.Subscribe(el => Console.WriteLine(el));
            
            var even = from num in o
                where (num % 2) == 0
                      select new { EvenNumber = num};
            
            even.Subscribe(el => Console.WriteLine(el.EvenNumber), () => {Console.WriteLine("DONE");});
            
            even = o.Where(el => (el % 2) == 0).Select(el => new { EvenNumber = el});
            
            even.Subscribe(el => Console.WriteLine(el.EvenNumber));
            
            Console.ReadKey();
        }
    }
}
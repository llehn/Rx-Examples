using System;
using System.Linq;

namespace Demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            var e = Enumerable.Range(1, 10);

            foreach (var i in e)
            {
                Console.WriteLine(i);
            }
            
            var even = from num in e
                where (num % 2) == 0
                select new { EvenNumber = num > 5 ? num : throw new NotSupportedException() };
            
            foreach (var i in even)
            {
                Console.WriteLine(i.EvenNumber);
            }
            
            even = e.Where(el => (el % 2) == 0).Select(el => new { EvenNumber = el});
            foreach (var i in even)
            {
                Console.WriteLine(i.EvenNumber);
            }
        }
    }
}
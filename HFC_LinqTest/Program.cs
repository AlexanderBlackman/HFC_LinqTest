using System;
using System.Linq;
using System.Collections.Generic;

namespace HFC_LinqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*        List<int> numbers = new List<int>();
                    for (int i = 1; i <= 99; i++)
                        numbers.Add(i);
                    IEnumerable<int> firstAndLastFive = numbers.Take(5).Concat(numbers.TakeLast(5));
                    foreach (int i in firstAndLastFive)
                        Console.Write($"{i} ");
                    Console.WriteLine();
                    int[] values = new int[] { 0, 12, 44, 36, 92, 54, 13, 8 };
                    IEnumerable<int> result =
                        from v in values
                        where v < 37
                        orderby -v
                        select v;
                    foreach (int i in result)
                        Console.Write($"{i} ");

                    Console.WriteLine();

                    var sandwiches = new[] { "ham and cheese", "salami with mayo", "turkey and swiss", "chicken cutlets" };
                    var sandwichOnRye =
                        from sandwich in sandwiches
                        select $"{sandwich} on rye";
                    foreach(var sandwich in sandwichOnRye)
                        Console.WriteLine(sandwich);

                    Console.WriteLine("Stats practice: ");

                    var random = new Random();
                    var petnumbers = new List<int>();
                    int length = random.Next(50, 150); 
                    for (int i = 0; i < length; i++)
                        petnumbers.Add(random.Next(100));

                    Console.WriteLine($@"Stats for these {petnumbers.Count()} numbers:
                    The first 7 numbers: {String.Join("> ", petnumbers.Take(7))}
                    The last 7 numbers: {String.Join("> ", petnumbers.TakeLast(7))}
                    The average is: {petnumbers.Average():F3}")
                    ;
            */
            var listOfObjects = new List<PrintWhenGetting>();
            for (int i = 1; i < 5; i++)
                listOfObjects.Add(new PrintWhenGetting() { InstanceNumber = i });
            Console.WriteLine("Set up the query");
            var result =
                from o in listOfObjects
                select o.InstanceNumber;
            Console.WriteLine("Run the foreach");
            foreach (var number in result)
            {
                Console.WriteLine($"Writing #{number}");
            }


            int[] fibonacci = { 0, 1, 1, 2, 3, 5 };
            // Construct the query
            IEnumerable<int> numbersGreaterThanTwoQuery = fibonacci.Where(x => x > 2)
             //   .ToArray()//But converting it to an array executes it immediately.
                ;
            // At this point the query has been created but not executed
            // Change the first element of the input sequence
            fibonacci[0] = 99;
            // Cause the query to be executed (enumerated)
            foreach (var number in numbersGreaterThanTwoQuery)
            {
                Console.WriteLine(number);
            }
        }
    }

    class PrintWhenGetting
    {
        private int instanceNumber;
        public int InstanceNumber
        {
            set { instanceNumber = value; }
            get
            {
                Console.WriteLine($"Getting #{instanceNumber}");
                return instanceNumber;
            }
        }
    }
}

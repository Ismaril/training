using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax_NET_core
{

    internal static class LINQ
    {
        // In order to use LINQ on custom classes, 
        //  you need to implement IEnumerable<T> interface.

        public static void Main__()
        {
            var utilities = new Utilities();
            utilities.PrintLine();

            var trainings = new Trainings__();
            foreach (Training__ training in trainings)
            {
                Console.WriteLine(training.Name);
            }

            utilities.PrintLine();

            int[] myList = { 100, 200, 300, 400 };
            foreach (var item in myList.MyFindAll(x => x > 200))
            {
                Console.WriteLine(item);
            }

            utilities.PrintLine();  

            IEnumerable<Training__> listOfFilteredTrainings;
            //listOfFilteredTrainings = trainings.Where(x => x.Name.Contains("C#"));
            //trainings.ToList().ForEach(x => Console.WriteLine(x.Name));

            // Use concatenation of extension methods.
            // This code does the same as those two lines above.
            trainings
                .Where(x => x.Name.Contains("C#")).ToList()
                .ForEach(x => Console.WriteLine(x.Name));

            utilities.PrintLine();

            IEnumerable<Training__> listos = trainings
                .Where(training => training.Name.Contains("C#"))
                .Select(training => training);
            foreach (var item in listos) {Console.WriteLine(item.Name);}

            utilities.PrintLine();

            // You can use Select method to select only the properties you want.
            IEnumerable<string> listos2 = trainings
                .Where(training => training.Name.Contains("ASP"))
                .Select(training => training.Name);
            foreach (var item_ in listos2) { Console.WriteLine(item_); }

            utilities.PrintLine();

            // See that we can use anonyous type in Select method.
            // Then we can use it in foreach loop and it will automatically print all properties.
            var listos3 = trainings
                .Where(training => training.Name.Contains("JavaScript"))
                .Select(training => new { training.Name, training.Name.Length, TimeStamp = DateTime.Now });
            foreach (var item in listos3) { Console.WriteLine(item); }

            // LINQ
            // Here is the LINQ query syntax applied to examples above.
            var list1 = from training in trainings
                         where training.Name.Contains("C#")
                         select training;
            foreach (var item in list1) { Console.WriteLine(item.Name); }

            utilities.PrintLine();

            var list2 = from training in trainings
                        where training.Name.Contains("ASP")
                        select training.Name;
            foreach (var item in list2) { Console.WriteLine(item); }

            utilities.PrintLine();

            var list3 = from training in trainings
                        where training.Name.Contains("JavaScript")
                        select new { training.Name, training.Name.Length, TimeStamp = DateTime.Now };
            foreach (var item in list3) { Console.WriteLine(item); }

            utilities.PrintLine();

            // Just an examples with explicit types, nothing else.
            decimal[] myDecimals = { 1.1m, 2.2m, 3.3m, 4.4m };
            var myDecimalsResult = from myDecimal in myDecimals
                                   where myDecimal > 2.2m
                                   select myDecimal;
            foreach (var item in myDecimalsResult) { Console.WriteLine(item); }

            List<int> myExplicitList = new List<int> { 1, 2, 3, 4, 5 };
            var myExplicitListResult = from myExplicitListItem in myExplicitList
                                       where myExplicitListItem > 3
                                       select myExplicitListItem;
        }

        class Training__
        {
            public string Name { get; set; }
            public Training__(string name)
            {
                Name = name;
            }
        }

        class Trainings__: IEnumerable<Training__>
        {
            private List<Training__> _trainings = new();

            public Trainings__()
            {
                _trainings.Add(new Training__("C#"));
                _trainings.Add(new Training__("ASP.NET"));
                _trainings.Add(new Training__("SQL"));
                _trainings.Add(new Training__("JavaScript"));
            }

            IEnumerator<Training__> IEnumerable<Training__>.GetEnumerator()
            {
                return new TrainingEnumerator(_trainings.ToArray());
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<Training__>)this).GetEnumerator();
            }



        }

        class TrainingEnumerator: IEnumerator<Training__>
        {
            int _index = -1;
            Training__[] _trainings;

            public TrainingEnumerator(Training__[] trainings)
            {
                _trainings = trainings;
            }

            Training__ IEnumerator<Training__>.Current
            {
                get { return _trainings[_index]; }
            }

            object IEnumerator.Current
            {
                get { return ((IEnumerator<Training__>)this).Current; }

            }

            public bool MoveNext()
            {
                _index++;
                return (_index < _trainings.Length);
            }

            public void Reset() { _index = -1; }

            public void Dispose() { }
        }


    }
    static class IEnumerableExtender
    {
        // This is an extension method. Check the syntax_NET_core/ExtensionMethods.cs file for more info.
        // This is a our custom implementation of the FindAll method.
        public static IEnumerable<T> MyFindAll<T>(this IEnumerable<T> list, Predicate<T> function)
        {
            foreach (var item in list)
            {
                if (function(item))
                {
                    yield return item;
                }
            }
        }
    }
}

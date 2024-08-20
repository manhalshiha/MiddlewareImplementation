using MiddlewareImplementation.Sorters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareImplementation.SortingApp
{
    public class SortingApp
    {
        private readonly List<Func<SortingContext, RequestDelegate, RequestDelegate>> _middleware = new();
        private RequestDelegate _delegate;
        public SortingApp()
        {
            _delegate = SortNumbers;
        }
        public SortingContext Context { get; } = new();
        public void Use(Func<SortingContext,RequestDelegate,RequestDelegate> middleware)
        {
            _middleware.Add(middleware);
        }
        public void Sort(List<int> numbers)
        {
            Context.Request = numbers;
            for (int i = 0; i < _middleware.Count; i++)
            {
                var middleware = _middleware[i];
                _delegate = middleware(Context, _delegate);   
                //
            }
            _delegate(Context);
        }
        private void SortNumbers(SortingContext context)
        {
            if (context.Algorithm == SortingAlgorithm.BubbleSort)
            {
                Console.WriteLine("Sorting via bubble sort");
                var sorter = new BubbleSorter();
                context.Response = sorter.Sort(context.Request);
            }
            else if (context.Algorithm == SortingAlgorithm.InsertionSort)
            {
                Console.WriteLine("Sorting via insertion sort");
                var sorter = new InsertionSorter();
                context.Response = sorter.Sort(context.Request);
            }
            else
            {
                Console.WriteLine("Sorting via selection sort");
                var sorter = new SelectionSorter();
                context.Response = sorter.Sort(context.Request);
            }
        }
    }
}

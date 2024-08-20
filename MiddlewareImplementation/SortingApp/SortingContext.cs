using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareImplementation.SortingApp
{
    public class SortingContext
    {
        public List<int> Request { get; set; } = new();
        public List<int> Response { get; set; } = new();
        public SortingAlgorithm Algorithm { get; set; } = SortingAlgorithm.BubbleSort;

    }
}

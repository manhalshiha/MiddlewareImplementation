using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareImplementation.Sorters
{
    public class SelectionSorter
    {
        public List<int> Sort(List<int> numbers)
        {
            List<int> sorted = numbers;
            int n = sorted.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i+1; j < n; j++)
                {
                    if (sorted[j] < sorted[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = sorted[minIndex];
                sorted[minIndex] = sorted[i];
                sorted[i] = temp;
            }
            return sorted;
        }
    }
}

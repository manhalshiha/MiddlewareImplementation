using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareImplementation.Sorters
{
    public class InsertionSorter
    {
        public List<int> Sort(List<int> numbers)
        {
            List<int> sorted = numbers;
            int n = sorted.Count;
            for (int i = 1; i < n ; i++)
            {
                int key = sorted[i];
                int j = i - 1;
                while (j >= 0 && sorted[j]>key)
                {
                    sorted[j + 1] = sorted[j];
                    j--;
                }
                sorted[j+1]=key;
            }
            return sorted;
        }
    }
}

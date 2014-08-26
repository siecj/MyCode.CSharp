using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCode.CSharp.Algorithms
{
    public class QuickSort
    {
        public static void Sort(List<int> src, int start, int end)
        {
            if (start < end)
            {
                int mid = Partition(src, start, end);
                Sort(src, start, mid - 1);
                Sort(src, mid + 1, end);
            }
        }

        public static int Partition(List<int> src, int start, int end)
        {
            int x = src[end];
            int i = start - 1;
            for (int j = start; j < end; j++)
            {
                if (src[j] <= x)
                {
                    i++;
                    int tmp = src[i];
                    src[i] = src[j];
                    src[j] = tmp;
                }
            }
            src[end] = src[i + 1];
            src[i + 1] = x;

            return i + 1;
        }
    }
}

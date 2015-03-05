using System;
using System.Collections.Generic;
using System.Linq;

namespace KKogut.SortAlgorithms
{
    public static class Sort
    {
        public static IEnumerable<T> BubbleSort<T>(this IEnumerable<T> array) where T : IComparable
        {
            var arr = array.ToArray<T>();

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if(arr[j].CompareTo(arr[j]) < 0)
                    {
                        var tmp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = tmp;
                    }
                }
            }

            return arr;
        }

        public static IEnumerable<T> InsertionSort<T>(this IEnumerable<T> array) where T : IComparable
        {
            var arr = array.ToArray<T>();
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i - 1;
                var curr = arr[i];
                while (j >= 0 && curr.CompareTo(arr[j]) < 0)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = curr;
            }

            return arr;
        }

        public static IEnumerable<T> SelectionSort<T>(this IEnumerable<T> array) where T : IComparable
        {
            var arr = array.ToArray<T>();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                var minIndex = i;
                var minValue = arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j].CompareTo(minValue) < 0)
                    {
                        minIndex = j;
                        minValue = arr[j];
                    }
                }
                arr[minIndex] = arr[i];
                arr[i] = minValue;
            }

            return arr;
        }

        public static IEnumerable<T> MergeSort<T>(this IEnumerable<T> array) where T : IComparable
        {
            if (array.Count() <= 1)
            {
                return array;
            }

            var mid = array.Count() / 2;
            var leftArr = MergeSort<T>(array.Take(mid));
            var rightArr = MergeSort<T>(array.Skip(mid));

            return Merge<T>(leftArr, rightArr);
        }

        private static IEnumerable<T> Merge<T>(IEnumerable<T> left, IEnumerable<T> right) where T : IComparable
        {
            var result = new List<T>();
            var leftArr = left.ToArray();
            var rightArr = right.ToArray();

            var l = 0;
            var r = 0;
            while (l < leftArr.Length && r < rightArr.Length)
            {
                if (leftArr[l].CompareTo(rightArr[r]) < 1)
                {
                    result.Add(leftArr[l]);
                    l++;
                }
                else
                {
                    result.Add(rightArr[r]);
                    r++;
                }
            }
            while (l < leftArr.Length)
            {
                result.Add(leftArr[l]);
                l++;
            }
            while (r < rightArr.Length)
            {
                result.Add(rightArr[r]);
                r++;
            }

            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace KKogut.SortAlgorithms
{
    public static class Sort
    {
        public static T[] BubbleSort<T>(this T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        var tmp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;
                    }
                }
            }

            return array;
        }

        public static T[] InsertionSort<T>(this T[] array) where T : IComparable
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i - 1;
                var curr = array[i];
                while (j >= 0 && curr.CompareTo(array[j]) < 0)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = curr;
            }

            return array;
        }

        public static T[] SelectionSort<T>(this T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                var minIndex = i;
                var minValue = array[i];
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(minValue) < 0)
                    {
                        minIndex = j;
                        minValue = array[j];
                    }
                }
                array[minIndex] = array[i];
                array[i] = minValue;
            }

            return array;
        }

        public static T[] MergeSort<T>(this T[] array) where T : IComparable
        {
            if (array.Count() <= 1)
            {
                return array;
            }

            var mid = array.Count() / 2;
            var leftarray = MergeSort<T>(array.Take(mid).ToArray());
            var rightarray = MergeSort<T>(array.Skip(mid).ToArray());

            return Merge<T>(leftarray, rightarray);
        }

        private static T[] Merge<T>(T[] left, T[] right) where T : IComparable
        {
            var result = new T[left.Length + right.Length];

            var l = 0;
            var r = 0;
            var i = 0;
            while (l < left.Length && r < right.Length)
            {
                if (left[l].CompareTo(right[r]) < 1)
                {
                    result[i] = left[l];
                    l++;
                }
                else
                {
                    result[i] = right[r];
                    r++;
                }
                i++;
            }

            while (l < left.Length)
            {
                result[i] = left[l];
                i++;
                l++;
            }
            
            while (r < right.Length)
            {
                result[i] = right[r];
                i++;
                r++;
            }

            return result;
        }

        public static T[] QuickSort<T>(this T[] array) where T : IComparable
        {
            if (array.Count() <= 1)
            {
                return array;
            }

            QuickSort<T>(array, 0, array.Length - 1);
            return array;
        }

        private static void QuickSort<T>(T[] array, int left, int right) where T : IComparable
        {
            if (left < right)
            {
                var pivot = Partition<T>(array, left, right);
                QuickSort(array, left, pivot - 1);
                QuickSort(array, pivot + 1, right);
            }
        }

        private static int Partition<T>(T[] array, int left, int right) where T : IComparable
        {
            var pivotIndex = ChoosePivot(array, left, right);
            var pivotValue = array[pivotIndex];
            // move pivot to the end
            var tmp = array[pivotIndex];
            array[pivotIndex] = array[right];
            array[right] = tmp;
            var s = left;
            for (int i = left; i < right; i++)
            {
                if (array[i].CompareTo(pivotValue) < 0)
                {
                    tmp = array[i];
                    array[i] = array[s];
                    array[s] = tmp;
                    s++;
                }
            }
            // insert pivot into its proper place
            tmp = array[s];
            array[s] = array[right];
            array[right] = tmp;
            return s;
        }

        private static int ChoosePivot<T>(T[] array, int left, int right) where T : IComparable
        {
            // could use sth else, e.g. random or median
            return left;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class SortAlgorithms
    {
        public static int OpCount;

        #region Bubble Sort
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        public static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j+1])
                    {
                        Swap(ref arr[j],ref arr[j + 1]);
                    }
                }
            }
        }
        #endregion

        #region Selection Sort
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        public static void SelectionSort(int[] arr) 
        {
            OpCount = 0;
            int minIndex;
            for (int i = 0; i < arr.Length; i++)
            {
                minIndex = i;
                for (int j = i + 1;j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                }
                Swap(ref arr[i], ref arr[minIndex]);
            }
            #region Insertion Sort
            
        }

        ///<summary>
        ///삽입정렬
        ///현재위치보다 이전 위치들중 더 큰 값이 있으면 해당값을 그다음 인덱스에 덮어쓰고
        ///위 과정이 끝나면 마지막으로 찾았던 큰값 인덱스 위치에 현재 탐색하던 위치에 값(key) 를 덮어줌
        ///</summary>
        ///<param name="arr"></param>
        public static void InsertionSort(int[] arr)
        {
            OpCount = 0;
            int key;
            int j;
            for (int i = 0; i < arr.Length; i++)
            {
                key = arr[i];
                j = i - 1;
                OpCount += 2;
                while (j >= 0 &&
                    arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
                OpCount += 1;
            }
        }
        #endregion

        #region Merge Sort
        /// <summary>
        /// 병합정렬
        /// 
        /// </summary>
        /// <param name="arr"></param>
        public static void MergeSort(int[] arr) 
        {
            MergeSort(arr, 0, arr.Length - 1);
        }

        public static void MergeSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int mid = end + (start - end) / 2 - 1;
                MergeSort(arr, start, mid);
                MergeSort(arr, mid + 1, end);
            
                Merge(arr, start, mid, end);
            }
        }

        private static void Merge(int[] arr, int start, int mid, int end)
        {
            int[] tmp = new int[end - start + 1];
            for (int i = 0; i <= end - start; i++)
                tmp[i] = arr[i + start];

            int part1 = start;
            int part2 = mid + 1;
            int index = start;
                
            while (part1 <= mid &&
                   part2 <= end)
            {
                if (tmp[part1 - start] <= tmp[part2 - start])
                {
                    arr[index++] = tmp[part1++ - start];
                }

                else 
                {
                    arr[index++] = tmp[part2++ - start];
                }
            }
            
            //남은 part1을 뒤에 쭉 이어붙여줌
            //남은 part2는 이미 정복된 상태기 때문에 그대로 쓰면됨
            for (int i = 0; i < mid - part1; i++)
            {
                arr[index + i] = tmp[part1 - start + i];
            }
        }

        #endregion

        #region Quick Sort

        public static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }

        public static void QuickSort(int[] arr, int start, int end)
        {

        }

        private static int Partition(int[] arr, int start, int end)
        {
            int pivot = arr[end + (start - end)/2];

            while (true)
            {
                while (arr[start] < pivot) start++;
                while (arr[end] > pivot) end--;
                
                if (start < end)
                {
                    Swap(ref arr[start], ref arr[end]);
                }
                else
                {
                    return end; // return pivot index
                }
            }
        }

        #endregion

        #region
        // ref 키워드 : 인자로 참조를 받고싶을 경우 사용.
        // out 키워드 : 함수 반환시 해당 파라미터 값을 반환하고 싶을 때 사용.
        private static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
            OpCount += 3;
        }
        #endregion
    }
}

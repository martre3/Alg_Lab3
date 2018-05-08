using System;
namespace Lab3
{
    class HeapSort : ISort
    {
        public void Sort(int[] numbers)
        {
            int size = numbers.Length;

            for (int p = (size - 1) / 2; p >= 0; --p)
                Heapify(numbers, size, p);

            for (int i = numbers.Length - 1; i > 0; --i)
            {
                size--;
                Swap(numbers, i, 0);
                Heapify(numbers, size, 0);
            }
        }

        private void Swap(int[] list, int i, int p)
        {
            int tmp = list[i];
            list[i] = list[p];
            list[p] = tmp;
        }

        private void Heapify(int[] numbers, int size, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if (left < size && numbers[left] > numbers[index])
                largest = left;
            else
                largest = index;

            if (right < size && numbers[right] > numbers[largest])
                largest = right;

            if (largest != index)
            {
                Swap(numbers, largest, index);

                Heapify(numbers, size, largest);
            }
        }
    }
}

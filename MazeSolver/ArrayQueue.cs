using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MazeSolver
{
    class ArrayQueue
    {
        private int left = 0, right = 0;
        private object[] arr = new object[1000000];

        public ArrayQueue() { }

        public ArrayQueue(int[] array)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                this.Enqueue(array[i]);
            }
        }

        public void Enqueue(object item)
        {
            arr[right++] = item;
        }

        public object Dequeue()
        {
            if (this.IsEmpty())
            {
                Console.WriteLine("Error");
                Environment.Exit(0);
            }
            return arr[left++];
        }

        public bool IsEmpty() => Size() == 0;

        public int Size() => right - left;

        public void Print()
        {
            object[] tempArr = new object[this.Size()];
            int i = this.Size() - 1;

            while (!this.IsEmpty())
            {
                tempArr[i] = this.Dequeue();
                i--;
            }

            Console.Write("[");
            for (i = 0; i < tempArr.Length; i++)
            {
                Console.Write(tempArr[i]);
                if (i != tempArr.Length - 1)
                    Console.Write(", ");
            }
            Console.Write("]");
        }

        public static void Main01(string[] args)
        {
            string input = Console.ReadLine();
            string cleanedInput = input.Replace("[", "").Replace("]", "");
            string[] splitInput = cleanedInput.Split(", ", StringSplitOptions.RemoveEmptyEntries);
            int[] arr = splitInput.Length > 0 && !string.IsNullOrEmpty(splitInput[0])
                ? splitInput.Select(int.Parse).ToArray()
                : new int[0];

            ArrayQueue queue = input.Length != 2 ? new ArrayQueue(arr) : new ArrayQueue();

            string command = Console.ReadLine();
            switch (command)
            {
                case "enqueue":
                    int element = int.Parse(Console.ReadLine());
                    queue.Enqueue(element);
                    queue.Print();
                    break;
                case "dequeue":
                    queue.Dequeue();
                    queue.Print();
                    break;
                case "isEmpty":
                    Console.WriteLine(queue.IsEmpty() ? "True" : "False");
                    break;
                case "size":
                    Console.Write(queue.Size());
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }

}

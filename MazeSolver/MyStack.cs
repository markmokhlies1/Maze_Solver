using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    public class MyStack
    {
        private int _size = 0;
        private object[] arr = new object[1000000];

        public object Pop()
        {
            if (_size == 0)
            {
                Console.Write("Error");
                Environment.Exit(0);
            }
            return arr[--_size];
        }

        public object Peek()
        {
            if (_size == 0)
            {
                Console.Write("Error");
                Environment.Exit(0);
            }
            return arr[_size - 1];
        }

        public void Push(object element)
        {
            arr[_size++] = element;
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public int Size()
        {
            return _size;
        }

        public static void Main01(string[] args)
        {
            MyStack stack = new MyStack();

            string input = Console.ReadLine().Replace("[", "").Replace("]", "");
            string[] splitInput = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
            int[] arr = splitInput.Length > 0 && !string.IsNullOrEmpty(splitInput[0])
                ? splitInput.Select(int.Parse).ToArray()
                : new int[0];

            for (int i = 0; i < arr.Length; i++)
                stack.Push(arr[arr.Length - i - 1]);

            string command = Console.ReadLine();

            switch (command)
            {
                case "push":
                    int value = int.Parse(Console.ReadLine());
                    stack.Push(value);
                    break;
                case "pop":
                    stack.Pop();
                    break;
                case "peek":
                    Console.Write(stack.Peek());
                    Environment.Exit(0);
                    break;
                case "isEmpty":
                    Console.Write(stack.IsEmpty() ? "True" : "False");
                    Environment.Exit(0);
                    break;
                case "size":
                    Console.Write(stack.Size());
                    Environment.Exit(0);
                    break;
                default:
                    Console.Write("Error");
                    Environment.Exit(0);
                    break;
            }

            Console.Write("[");
            while (!stack.IsEmpty())
            {
                Console.Write(stack.Pop());
                if (stack.Size() != 0)
                    Console.Write(", ");
            }
            Console.Write("]");
        }
    }
}

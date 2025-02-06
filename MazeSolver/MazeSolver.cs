using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace MazeSolver
{
    public class MazeSolver : IMazeSolver
    {
        public int m, n, sx, sy, ex, ey;
        public string[] arr;

        public int[][] SolveBFS(FileInfo maze)
        {
            try
            {
                using StreamReader sr = new StreamReader(maze.FullName);
                string[] s = sr.ReadLine().Split(' ');
                m = int.Parse(s[0]);
                n = int.Parse(s[1]);
                arr = new string[m];

                for (int i = 0; i < m; i++)
                {
                    arr[i] = sr.ReadLine();
                    Console.WriteLine(arr[i]);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Maze.txt not found..!");
                return new int[0][];
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (arr[i][j] == 'S') { sx = i; sy = j; }
                    else if (arr[i][j] == 'E') { ex = i; ey = j; }
                }
            }

            bool[,] visited = new bool[m, n];
            Point[,] parents = new Point[m, n];
            Queue<Point> q = new();
            Queue<Point> previous = new();

            q.Enqueue(new Point(sx, sy));
            previous.Enqueue(new Point(-1, -1));
            bool done = false;

            while (q.Count > 0)
            {
                Point current = q.Dequeue();
                int x = current.X, y = current.Y;
                Point prev = previous.Dequeue();
                if (x < 0 || y < 0 || x >= m || y >= n || arr[x][y] == '#' || visited[x, y])
                    continue;

                visited[x, y] = true;
                parents[x, y] = prev;

                if (x == ex && y == ey)
                {
                    done = true;
                    break;
                }

                q.Enqueue(new Point(x - 1, y));
                q.Enqueue(new Point(x + 1, y));
                q.Enqueue(new Point(x, y - 1));
                q.Enqueue(new Point(x, y + 1));

                for (int i = 0; i < 4; i++)
                    previous.Enqueue(new Point(x, y));
            }

            if (!done)
            {
                Console.WriteLine("NOT FOUND");
                Environment.Exit(0);
            }

            List<Point> path = new();
            int px = ex, py = ey;
            while (true)
            {
                path.Add(new Point(px, py));
                if (px == sx && py == sy)
                    break;
                Point p = parents[px, py];
                px = p.X;
                py = p.Y;
            }
            path.Reverse();
            return path.ConvertAll(p => new int[] { p.X, p.Y }).ToArray();
        }

        public int[][] SolveDFS(FileInfo maze)
        {
            bool[,] visited = new bool[m, n];
            Point[,] parents = new Point[m, n];
            Stack<Point> stack = new();
            Stack<Point> previous = new();

            stack.Push(new Point(sx, sy));
            previous.Push(new Point(-1, -1));
            bool done = false;

            while (stack.Count > 0)
            {
                Point current = stack.Pop();
                int x = current.X, y = current.Y;
                Point prev = previous.Pop();
                if (x < 0 || y < 0 || x >= m || y >= n || arr[x][y] == '#' || visited[x, y])
                    continue;

                visited[x, y] = true;
                parents[x, y] = prev;

                if (x == ex && y == ey)
                {
                    done = true;
                    break;
                }

                stack.Push(new Point(x - 1, y));
                stack.Push(new Point(x + 1, y));
                stack.Push(new Point(x, y - 1));
                stack.Push(new Point(x, y + 1));

                for (int i = 0; i < 4; i++)
                    previous.Push(new Point(x, y));
            }

            if (!done)
            {
                Console.WriteLine("NOT FOUND");
                Environment.Exit(0);
            }

            List<Point> path = new();
            int px = ex, py = ey;
            while (true)
            {
                path.Add(new Point(px, py));
                if (px == sx && py == sy)
                    break;
                Point p = parents[px, py];
                px = p.X;
                py = p.Y;
            }
            path.Reverse();
            return path.ConvertAll(p => new int[] { p.X, p.Y }).ToArray();
        }

    }

}

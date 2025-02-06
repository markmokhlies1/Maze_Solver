
namespace MazeSolver
{
    internal class Program
    {
        public static void Main()
        {
            MazeSolver solver = new();
            string fileName = "maze10.txt";
            FileInfo file = new(fileName);

            int[][] bfs = solver.SolveBFS(file);
            foreach (var point in bfs)
                Console.Write($"({point[0]} ,{point[1]}) ,");
            Console.WriteLine($"({solver.ex} ,{solver.ey})");

            int[][] dfs = solver.SolveDFS(file);
            foreach (var point in dfs)
                Console.Write($"({point[0]} ,{point[1]}) ,");
            Console.WriteLine($"({solver.ex} ,{solver.ey})");
        }
    }
}

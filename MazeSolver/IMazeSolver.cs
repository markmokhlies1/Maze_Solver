using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    public interface IMazeSolver
    {
        int[][] SolveBFS(FileInfo maze);
        int[][] SolveDFS(FileInfo maze);
    }
}

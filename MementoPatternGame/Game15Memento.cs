using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPatternGame
{
    class Game15Memento
    {
        public int[,] Area { get; set; }
        public int N { get; set; }
        public int Count { get; set; }

        public Game15Memento(int[,] area, int n, int count)
        {
            Area = area;
            N = n;
            Count = count; 
        }
    }
}

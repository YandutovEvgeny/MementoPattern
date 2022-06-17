using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPatternGame
{
    class Game15History
    {
        public List<Game15Memento> History { get; set; }

        public Game15History()
        {
            History = new List<Game15Memento>();
        }
    }
}

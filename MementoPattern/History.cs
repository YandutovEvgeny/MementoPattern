using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPattern
{
    class History
    {
        public Stack<MementoControl> ControlHistory { get; set; }

        public History()
        {
            ControlHistory = new Stack<MementoControl>();
        }
    }
}

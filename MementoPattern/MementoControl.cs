using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPattern
{
    class MementoControl
    {
        public Point Position { get; private set; }
        public Color Color { get; private set; }

        public MementoControl(Point position, Color controlColor)
        {
            Position = position;
            Color = controlColor;
        }
    }
}

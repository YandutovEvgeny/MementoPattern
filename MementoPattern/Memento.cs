using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MementoPattern
{
    class Memento
    {
        Point position;
        Color color;
        Control control;    //Button, textbox - это всё Control

        public Memento(Point position, Color color, Control control)
        {
            this.position = position;
            this.color = color;
            this.control = control;
        }

        public void NewPosition(Point position)
        {
            this.position = position;
            control.Left = position.X;
            control.Top = position.Y;
        }
        public void NewColor(Color color)
        {
            this.color = color;
            control.BackColor = color;
        }
        public MementoControl Save()
        {
            return new MementoControl(position, color);
        }
        public void Load(MementoControl mementoControl)
        {
            position = mementoControl.Position;
            color = mementoControl.Color;
            control.Left = position.X;
            control.Top = position.Y;
            control.BackColor = color;
        }
    }
}

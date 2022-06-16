using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MementoPattern
{
    public partial class Form1 : Form
    {
        Memento memento;
        History history;
        Random random;
        public Form1()
        {
            InitializeComponent();
            memento = new Memento(button1.Location, button1.BackColor, button1);
            history = new History();
            history.ControlHistory.Push(memento.Save());
            random = new Random();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point point = new Point(random.Next(Height - button1.Height), 
                random.Next(Width - button1.Width));
            Color color = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
            memento.NewColor(color);
            memento.NewPosition(point);
            history.ControlHistory.Push(memento.Save());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (history.ControlHistory.Count != 0)
                memento.Load(history.ControlHistory.Pop());
            else
                MessageBox.Show("Дальше некуда, стэк пуст");
        }
    }
}

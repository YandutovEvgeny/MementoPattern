using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using GlobalHotKey;

namespace MementoPatternGame
{
    public partial class Form1 : Form
    {
        Game15 game15;
        Game15Graphics game15Graphics;
        HotKeyManager keyManager;
        public Form1()
        {
            InitializeComponent();
            keyManager = new HotKeyManager();
            var hotKey = keyManager.Register(Key.Z, System.Windows.Input.ModifierKeys.Control);
            keyManager.KeyPressed += HotKeyManagerPressed;
        }

        private void HotKeyManagerPressed(object sender, KeyPressedEventArgs e)
        {
            game15.Undo();
            game15Graphics.Draw();
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game15 = new Game15();
            game15Graphics = new Game15Graphics(pictureBox1.CreateGraphics(), game15);
            game15Graphics.Draw();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (game15 != null && game15Graphics != null)
            {
                game15.SaveToHistory();
                game15.Move(e.X / 100, e.Y / 100);
                game15Graphics.Draw();
                if (game15.IsWin())
                    MessageBox.Show("Победа!"); 
            }
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game15.Undo();
            game15Graphics.Draw();
        }

        private void сохранитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "GAME15|*.gm15";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                game15.SaveToFile(saveFileDialog.FileName);
        }
    }
}

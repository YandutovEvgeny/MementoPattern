using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPatternGame
{
    class Game15Graphics
    {
        Graphics graphics;
        Game15 game15;
        Image image;
        public string Skin { get; set; }

        public Game15Graphics(Graphics graphics, Game15 game)
        {
            this.graphics = graphics;
            game15 = game;
            Skin = "C:\\Users\\Admin\\Downloads\\1.png";
            image = Image.FromFile(Skin);
        }

        public void Draw()
        {
            for (int i = 0; i < game15.N; i++)
            {
                for (int j = 0; j < game15.N; j++)
                {
                    if (game15.Area[j, i] != 0)
                    {
                        graphics.DrawImage(image, i * 100, j * 100, 100, 100);
                        graphics.DrawString(game15.Area[j, i].ToString(),
                            new Font("TimeNewRoman", 50),
                            new SolidBrush(Color.DarkOrange), i * 100, j * 100);
                    }
                    else
                    {
                        graphics.FillRectangle(new SolidBrush(Color.White), i * 100, j * 100, 100, 100);
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPatternGame
{
    class Game15
    {
        public int[,] Area { get; private set; }
        public int N { get; private set; }
        public int Count { get; private set; }
        Random random;
        Game15History game15History;

        public Game15(int n = 4)
        {
            random = new Random();
            N = n;
            Area = new int[N, N];
            NewGame();
        }

        public bool IsWin()
        {
            int num = 1;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i == N - 1 && j == N - 1)
                        return true;
                    
                    if (Area[i, j] != num++)
                        return false;
                }
            }
            return true;
        }
        public void Move(int x, int y)
        {
            Count++;
            if(x > 0 && Area[y,x-1] is 0)
            {
                Area[y, x - 1] = Area[y, x];
                Area[y, x] = 0;
            }
            if(y > 0 && Area[y - 1,x] is 0)
            {
                Area[y - 1, x] = Area[y, x];
                Area[y, x] = 0;
            }
            if(y < N-1 && Area[y + 1,x] is 0)
            {
                Area[y + 1, x] = Area[y, x];
                Area[y, x] = 0;
            }
            if(x < N-1 && Area[y,x + 1] is 0)
            {
                Area[y, x + 1] = Area[y, x];
                Area[y, x] = 0;
            }
        }
        public void SaveToFile(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine(Count);
            streamWriter.WriteLine(N);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    streamWriter.Write(Area[i, j]);
                    streamWriter.Write(" ");
                }
                streamWriter.WriteLine();
            }
            streamWriter.Flush();
        }
        public void SaveToHistory()
        {
            int[,] area = new int[N, N];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    area[i, j] = Area[i, j];
            if (game15History.History.Count > 10)
                game15History.History.RemoveAt(0);
            game15History.History.Add(new Game15Memento(area, N, Count));
        }
        public void Undo()
        {

            int n = game15History.History.Count;
            if (n > 0)
            {
                N = game15History.History[n - 1].N;
                Count = game15History.History[n - 1].Count;
                Area = game15History.History[n - 1].Area;
                game15History.History.RemoveAt(n - 1); 
            }
        }
        public void NewGame()
        {
            Count = 0;
            game15History = new Game15History();
            int number = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Area[i, j] = number++;
                }
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    int x = random.Next(N);
                    int y = random.Next(N);
                    int pos = Area[i, j];
                    Area[i, j] = Area[x, y];
                    Area[x, y] = pos;
                } 
            }
        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;
using Console_Game_PF_CSharp.BL;

namespace Console_Game_PF_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();
            Console.SetWindowSize(160, 40);
            Console.SetWindowPosition(0, 0);
            map.source = LoadMap();
            map.width = 131;
            map.height = 38;
            DisplayMap(map);
            Console.ReadKey();
        }

        static char[,] LoadMap()
        {
            char[,] map = new char[38, 131];
            int row = 0, col = 0;
            string path = "../../../Data/squareMap.txt";
            char buffer;
            StreamReader fileVariable = new StreamReader(path);
            do
            {
                buffer = (char)fileVariable.Read();
                if (buffer == '\r') continue;
                if (buffer == '\n')
                {
                    row++;
                    col = 0;
                }
                else
                {
                    map[row, col] = buffer;
                    col++;
                }
            } while (!fileVariable.EndOfStream);
            fileVariable.Close();
            return map;
        }

        static void DisplayMap(Map map)
        {
            for (int row = 0; row < map.height; row++)
            {
                for (int col = 0; col < map.width; col++)
                {
                    Console.Write(map.source[row, col]);
                }
                Console.Write('\n');
            }
        }
    }
}

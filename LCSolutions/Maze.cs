using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSolutions
{
    public class Maze : ILCSolutions
    {
        public void Test()
        {
            Console.WriteLine(this.GetType().Name);
            int[,] input = new int[,]
            {
               { 1, 0, 1, 1, 1 },
               { 1, 1, 1, 0, 1 },
               { 0, 0, 0, 1, 1 },
               { 0, 0, 0, 1, 0 },
               { 0, 0, 0, 1, 1 }
            };

            InputArray = input;
            Maze.PrintMatrix(InputArray);

            int startx = 0, starty = 0;
            int endx = 3, endy = 3;
            Console.WriteLine(string.Format("({0}, {1}) -> ({2}, {3})", startx, starty, endx, endy));
            
            FindPath(startx, starty, endx, endy);            
            Maze.PrintMatrix(InputArray);
            Console.WriteLine();
        }

        public int[,] InputArray { get; set; }
        

        public static int Pass = 1;

        public bool FindPath(int startx, int starty, int endx, int endy)
        {

            if (isInsideMaze(startx, starty, endx, endy))
            {
                if (InputArray[startx, starty] == Pass)
                {
                    // mark this point as a valid point
                    InputArray[startx, starty] = 6;

                    //Maze.PrintMatrix(InputArray);

                    // this is the end
                    if (startx == endx && starty == endy)
                        return true;

                    // move North
                    if (FindPath(startx - 1, starty, endx, endy))
                        return true;
                    // move east
                    if (FindPath(startx, starty + 1, endx, endy))
                        return true;
                    // move south
                    if (FindPath(startx + 1, starty, endx, endy))
                        return true;
                    // move west
                    if (FindPath(startx, starty - 1, endx, endy))
                        return true;

                    //unmark as a invalid point
                    InputArray[startx, starty] = 9;
                    return false;
                }
                else
                {
                    // blocked
                    return false;
                }
            }
            else
            {
                // outside maze
                return false;
            }
        }

        private bool isInsideMaze(int startx, int starty, int endx, int endy)
        {
            return startx > -1 && starty > -1 && startx < InputArray.GetLength(0) && starty < InputArray.GetLength(1)
                && endx > -1 && endy > -1 && endx < InputArray.GetLength(0) && endy < InputArray.GetLength(1);
        }

        public static void PrintMatrix(int[,] input)
        {
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    Console.Write(input[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();           
        }

    }
}

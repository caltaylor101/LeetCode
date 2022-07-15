using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class Day9
    {
        private bool srDone;
        private bool scDone;
        /*public int[][] FloodFill2(int[][] image, int sr, int sc, int color)
        {
            return image;
        }

        public int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            if (image.Length == 0) return image;
            if (image[sr][sc] == color) return image;


            bool down = sr + 1 < image.Length && image[sr][sc] == image[sr + 1][sc];
            bool up = sr - 1 >= 0 && image[sr - 1][sc] == image[sr][sc];
            bool right = sc + 1 < image[sr].Length && image[sr][sc + 1] == image[sr][sc];
            bool left = (sc - 1 >= 0 && image[sr][sc - 1] == image[sr][sc]);


            image[sr][sc] = color;


            if (down) FloodFill(image, sr + 1, sc, color);
            if (up)  FloodFill(image, sr - 1, sc, color);
            if (right) FloodFill(image, sr, sc + 1, color);
            if (left) FloodFill(image, sr, sc - 1, color);

            return image;
        }*/
        public int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            int startColor = image[sr][sc];
            return RecurseFill(image, sr, sc, color, startColor);
        }

        public int[][] RecurseFill(int[][] image, int sr, int sc, int color, int startColor)
        {
            if (startColor == color)
            {
                return image;
            }
            if (image[sr][sc] == startColor)
            {
                image[sr][sc] = color;
            }
            if (sr - 1 >= 0 && image[sr - 1][sc] == startColor)
            {
                image[sr-1][sc] = color;
                RecurseFill(image, sr - 1, sc, color, startColor);
            }
            if (sr + 1 < image.Length && image[sr + 1][sc] == startColor)
            {
                image[sr + 1][sc] = color;
                RecurseFill(image, sr + 1, sc, color, startColor);
            }
            if (sc - 1 >=0 && image[sr][sc - 1] == startColor)
            {
                image[sr][sc - 1] = color;
                RecurseFill(image, sr, sc - 1, color, startColor);
            }
            if (sc + 1 < image[sr].Length && image[sr][sc+1] == startColor)
            {
                image[sr][sc + 1] = color;
                RecurseFill(image, sr, sc + 1, color, startColor);
            }
            

            return image;
        }

        /*public int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            if (image.Length == 0) return image;
            if (image[sr][sc] == color) return image;

            bool down = (sr + 1) < image.Length && sr >= 0 && image[sr][sc] == image[sr + 1][sc];
            bool up = (sr - 1) < image.Length && sr >= 1 && image[sr][sc] == image[sr - 1][sc];
            bool right = (sc + 1) < image[sr].Length && sc >= 0 && image[sr][sc] == image[sr][sc + 1];
            bool left = (sc - 1) < image[sr].Length && sc >= 1 && image[sr][sc] == image[sr][sc - 1];

            image[sr][sc] = color;

            if (down) image = FloodFill(image, sr + 1, sc, color);
            if (up) image = FloodFill(image, sr - 1, sc, color);
            if (right) image = FloodFill(image, sr, sc + 1, color);
            if (left) image = FloodFill(image, sr, sc - 1, color);

            return image;

        }*/
        private int islands = 0;
        public int NumIslands(char[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        islands += RecurseIsland(grid, i, j);
                    }
                }
            }
            return islands;
        }

        public int RecurseIsland(char[][] grid, int x, int y)
        {
            if (x-1 >= 0 && grid[x - 1][y] == '1')
            {
                grid[x - 1][y] = '0';
                RecurseIsland(grid, x - 1, y);
            }
            if (x + 1 < grid.Length && grid[x + 1][y] == '1')
            {
                grid[x + 1][y] = '0';
                RecurseIsland(grid, x + 1, y);
            }
            if (y - 1 >= 0 && grid[x][y - 1] == '1')
            {
                grid[x][y - 1] = '0';
                RecurseIsland(grid, x, y - 1);
            }
            if (y + 1 < grid[x].Length && grid[x][y + 1] == '1')
            {
                grid[x][y + 1] = '0';
                RecurseIsland(grid, x, y + 1);
            }

            return 1;
        }
    }
}

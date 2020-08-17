using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login_Registration.Models
{
    public class BoardModel
    {
        public int Size { get; set; }
        public int Difficulty { get; set; }
        public CellModel[,] grid;

        public BoardModel(int s, int d)
        {
            Size = s;
            Difficulty = d;
            grid = new CellModel[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    grid[i, j] = new CellModel(i, j, false, false, 0, false);
                }
            }
        }
        //method to add bombs to random cells using difficulty level.
        public void activeBombs()
        {
            Random rng = new Random();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {

                    if (rng.Next(100) < Difficulty)
                    {
                        grid[i, j].hasBomb = true;
                    }

                }
            }
        }

        // method to count the number of neighbor with bombs
        public void calcNeighbors()
        {
            foreach (CellModel currentcell in grid)
            {
                if (currentcell.hasBomb == false)
                {
                    currentcell.neighborBombs = 0;
                    for (int r = -1; r <= 1; r++)
                    {
                        for (int c = -1; c <= 1; c++)
                        {
                            if (isValid(currentcell.RowNum + r, currentcell.ColumnNum + c) && grid[currentcell.RowNum + r, currentcell.ColumnNum + c].hasBomb == true)
                            {
                                currentcell.neighborBombs++;
                            }
                        }
                    }
                    if (currentcell.hasBomb == true)
                    {
                        currentcell.neighborBombs = 9;
                    }

                }
            }
        }

        //check for out of bound error and make sure 
        public bool isValid(int r, int c)
        {
            return (r >= 0 && r < Size && c >= 0 && c < Size);
        }

        // reveal neighbors that has the same number but not alive
        public void floodFill(int x, int y)
        {
            grid[x, y].isVisited = true;

            for (int r = -1; r <= 1; r++)
            {
                for (int c = -1; c <= 1; c++)
                {
                    if (isValid(x + r, y + c) && grid[x + r, y + c].isVisited == false && grid[x, y].neighborBombs == 0)
                    {

                        floodFill(x + r, y + c);
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Login_Registration.Controllers;

namespace Login_Registration.Models
{
    public class GameModel
    {
        public BoardModel board { get; set; }

        public GameModel()
        {
            this.board = new BoardModel(12, 10);
        }

        public void Turn(int rowNumber, int columNumber)
        {

            if (board.isValid(rowNumber, columNumber) && board.grid[rowNumber, columNumber].hasBomb == false)
            {


                if (this.board.grid[rowNumber, columNumber].neighborBombs == 0)
                {

                    board.floodFill(rowNumber, columNumber);
                }
                if (winCondition())
                {
                    
                    Debug.WriteLine("You win the game!!!");
                }
              
            }

            else if (board.isValid(rowNumber, columNumber) && this.board.grid[rowNumber, columNumber].hasBomb == true)
            {
                // when user clicks a bomb, 
                for (int i = 0; i < board.Size; i++)
                {
                    for (int j = 0; j < board.Size; j++)
                    {
                        board.grid[i, j].isVisited = true;
                    }
                }
                Debug.WriteLine("You lost this game. Try again");
            }


        }


        public bool winCondition()
        {

            bool winCondition = true;
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    // check for non visited squares that are not a bomb
                    if (board.grid[i, j].isVisited == false && board.grid[i, j].hasBomb == false)
                    {
                        winCondition = false;
                    }
                }

            }
            return winCondition;
        }
    }
}
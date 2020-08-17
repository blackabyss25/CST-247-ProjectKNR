using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login_Registration.Models;

namespace Login_Registration.Controllers
{
    public class GameController : Controller
    {
        static GameModel game = new GameModel();


        Random random = new Random();
        // GET: Game
        public ActionResult Index()
        {
            game.board.activeBombs();
            game.board.calcNeighbors();

            return View("Game", game);
        }

        public ActionResult Button(string mine)
        {

            String[] rc = mine.Split('|');

            Point p = new Point(int.Parse(rc[0]), int.Parse(rc[1]));

            game.board.grid[p.X, p.Y].isVisited = true;

            game.Turn(p.X, p.Y);


            return View("Game", game);
        }
    }
}
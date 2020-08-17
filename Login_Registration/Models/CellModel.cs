using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login_Registration.Models
{
    public class CellModel
    {
        public int RowNum { get; set; }
        public int ColumnNum { get; set; }
        public bool isVisited { get; set; }
        public bool hasBomb { get; set; }

        public int neighborBombs { get; set; }
        public bool cellFlagged { get; set; }

        public CellModel(int r, int c, bool v, bool b, int n, bool f)
        {
            RowNum = r;
            ColumnNum = c;
            isVisited = v;
            hasBomb = b;
            neighborBombs = n;
            cellFlagged = f;
        }
    }
}
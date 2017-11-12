using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sudoku.Models
{
    public class Momo
    {
        public int ID { get; set; }
        public int NanpreNO { get; set; }
        public string MakeUserID { get; set; }
        public bool IsPublic { get; set; }
        public string Title { get; set; }
        public string Remarks { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sudoku.Models
{
    public class NanpreQuestion
    {
        public int ID { get; set; }
        public int NanpreNO { get; set; }
        public string Nanpre { get; set; }
        public string NanpreAnswer { get; set; }
    }
}
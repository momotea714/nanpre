using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sudoku.Models
{
    public class Talk
    {
        public int ID { get; set; }
        public int Momo_ID { get; set; }
        public string SenderUser_ID { get; set; }
        public string DisplayName { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sudoku.Models
{
    public class MomoDBContext : DbContext
    {
        public MomoDBContext() : base("name=MomoDBContext")
        {
        }
        public System.Data.Entity.DbSet<Sudoku.Models.Momo> Momoes { get; set; }
        public System.Data.Entity.DbSet<Sudoku.Models.NanpreQuestion> NanpreQuestions { get; set; }
        public System.Data.Entity.DbSet<Sudoku.Models.MomoState> MomoStates { get; set; }
    }
}

using Sudoku.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sudoku.Controllers
{
    public class HomeController : Controller
    {
        private Dictionary<int, string> questionDic = new Dictionary<int, string>
            {
                {0,"001020703040000001000600002695040100002715000000000040000007300003050809900000200" },
                {1,"007008001000000460003065080020000000000094050019037024050400073000000000076059040" },
                {2,"130405760000000000790000850000940580000000002020006000003800000610507000070204090" },
                {3,"040000703017206000006003000700000040000000050050090302000805900400600580000002000" },
                {4,"000000003108006007349170000800000000002600070600510800006200040000050020000803900" },
                {5,"009300000038160540060000000040700210000000009010400380080002000420507890000800000" },
                {6,"000029060600030090004600080080000000140086000002000001305004000000000020920500043" },
                {7,"090300010804071020002060000045000190010005000300080000000000962400009005000200070" },
                {8,"000003014008052000350600000001008200900700030000000009000000040004005001800300900" },
                {9,"201400090007029030080010040000800970000060000305000010063004050900600700010000000" },
            };

        //public ActionResult Index()
        //{
        //    //http://funahashi.kids.coocan.jp/game/game651.html
            
        //    ViewData = new ViewDataDictionary(questionDic);
        //    ViewBag.nanpreID = null;
        //    return View();
        //}

        public ActionResult Index(int? id)
        {
            ViewData = new ViewDataDictionary(questionDic);
            ViewBag.nanpreid = id;
            //if (id != null)
            //{
            //    new MyHub().Join(id.ToString());
            //}
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
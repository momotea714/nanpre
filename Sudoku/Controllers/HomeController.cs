using Sudoku.Models;
using System.Linq;
using System.Web.Mvc;

namespace Sudoku.Controllers
{
    public class HomeController : Controller
    {
        #region メンバ変数
        private readonly MomoDBContext _db = new MomoDBContext();
        #endregion

        public ActionResult Index(int? id)
        {
            var nanpreNO = _db.Momoes.FirstOrDefault(x => x.ID == id).NanpreNO;

            //Momo(Room)に紐付くナンプレ番号を取得
            ViewBag.MomoStates = _db.MomoStates.FirstOrDefault(x => x.Momo_ID == id);
            ViewBag.NanpreQuestion = _db.NanpreQuestions.FirstOrDefault(x => x.NanpreNO == nanpreNO);

            return View();
        }

        public JsonResult IndexAPI(int id)
        {
            var nanpreNO = _db.Momoes.FirstOrDefault(x => x.ID == id).NanpreNO;
            //response
            var obj = new
            {
                currentQuestion = _db.MomoStates.FirstOrDefault(x => x.Momo_ID == id).CurrentNanpre,
                originalQuestion = _db.NanpreQuestions.FirstOrDefault(x => x.NanpreNO == nanpreNO).Nanpre,
            };

            //return
            return Json(obj, JsonRequestBehavior.AllowGet);
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
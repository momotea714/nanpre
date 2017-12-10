using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sudoku.Models;

namespace Sudoku.Controllers
{
    public class TalksController : Controller
    {
        private MomoDBContext db = new MomoDBContext();

        // GET: Talks
        public ActionResult Index()
        {
            return View(db.Talks.ToList());
        }

        public ActionResult SelectRoomTalk(int id)
        {
            return PartialView("_TalkPartialView", db.Talks.Where(x => x.Momo_ID == id).ToList());
        }

        public JsonResult SelectRoomTalkAPI(int id)
        {
            var questions = db.NanpreQuestions.OrderBy(x => x.NanpreNO).ToList();
            //return
            return Json(questions, JsonRequestBehavior.AllowGet);
        }

        // GET: Talks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talk talk = db.Talks.Find(id);
            if (talk == null)
            {
                return HttpNotFound();
            }
            return View(talk);
        }

        // GET: Talks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Talks/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Momo_ID,SenderUser_ID,DisplayName,Message,CreatedDateTime")] Talk talk)
        {
            if (ModelState.IsValid)
            {
                db.Talks.Add(talk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(talk);
        }

        // GET: Talks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talk talk = db.Talks.Find(id);
            if (talk == null)
            {
                return HttpNotFound();
            }
            return View(talk);
        }

        // POST: Talks/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Momo_ID,SenderUser_ID,DisplayName,Message,CreatedDateTime")] Talk talk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(talk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(talk);
        }

        // GET: Talks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talk talk = db.Talks.Find(id);
            if (talk == null)
            {
                return HttpNotFound();
            }
            return View(talk);
        }

        // POST: Talks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Talk talk = db.Talks.Find(id);
            db.Talks.Remove(talk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

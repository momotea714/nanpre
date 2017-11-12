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
    public class MomoesController : Controller
    {
        private MomoDBContext db = new MomoDBContext();

        // GET: Momoes
        public ActionResult Index()
        {
            return View(db.Momoes.ToList());
        }

        // GET: Momoes
        public JsonResult IndexAPI()
        {
            return new JsonResult() { Data = db.Momoes.ToList() };
        }

        // GET: Momoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Momo momo = db.Momoes.Find(id);
            if (momo == null)
            {
                return HttpNotFound();
            }
            return View(momo);
        }

        // GET: Momoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Momoes/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NanpreNO,MakeUserID,IsPublic,Title,Remarks")] Momo momo)
        {
            if (ModelState.IsValid)
            {
                db.Momoes.Add(momo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(momo);
        }

        // GET: Momoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Momo momo = db.Momoes.Find(id);
            if (momo == null)
            {
                return HttpNotFound();
            }
            return View(momo);
        }

        // POST: Momoes/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NanpreNO,MakeUserID,IsPublic,Title,Remarks")] Momo momo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(momo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(momo);
        }

        // GET: Momoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Momo momo = db.Momoes.Find(id);
            if (momo == null)
            {
                return HttpNotFound();
            }
            return View(momo);
        }

        // POST: Momoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Momo momo = db.Momoes.Find(id);
            db.Momoes.Remove(momo);
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

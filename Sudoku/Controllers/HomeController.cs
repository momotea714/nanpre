﻿using Sudoku.Hubs;
using Sudoku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sudoku.Controllers
{
    public class HomeController : Controller
    {
        private MomoDBContext db = new MomoDBContext();

        public ActionResult Index(int? id)
        {
            //Momo(Room)に紐付くナンプレ番号を取得
            ViewBag.MomoStates = db.MomoStates.FirstOrDefault(x => x.Momo_ID == id);
            return View();
        }

        public JsonResult IndexAPI(int id)
        {
            //response
            object obj = new
            {
                question = db.MomoStates.FirstOrDefault(x => x.Momo_ID == id).CurrentNanpre,
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
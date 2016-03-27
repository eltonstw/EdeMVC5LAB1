using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using LAB.Models;

namespace LAB.Controllers
{
    public class 客戶資料檢視表Controller : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: 客戶資料檢視表
        public ActionResult Index()
        {
            return View(db.客戶資料檢視表.Select(c => new CustomerDataViewModel()
            {
                客戶名稱 = c.客戶名稱,
                銀行帳戶數量 = c.銀行帳戶數量,
                聯絡人數量 = c.聯絡人數量
            }).ToList());
        }

        public ActionResult List(string input)
        {
            if (string.IsNullOrEmpty(input.Trim()))
            {
                return RedirectToAction("Index");
            }

            var data = db.客戶資料檢視表.Where(c => c.客戶名稱.Contains(input.Trim())).Select(c => new CustomerDataViewModel()
            {
                客戶名稱 = c.客戶名稱,
                銀行帳戶數量 = c.銀行帳戶數量,
                聯絡人數量 = c.聯絡人數量
            }).ToList();
            return View("Index", data);
        }
    }
}
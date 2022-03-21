using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationClientMVC.Models;

namespace WebApplicationClientMVC.Controllers
{
    public class fuelsController : Controller
    {
        private static Fuels _fuels;
        public static  Fuels fuels
        {
            get
            {
                return _fuels;
            }
            set
            {
                _fuels = value;
            }
        }
        public static Fuels GetFuels()
        {
            return fuels;
        }
        // GET: fuels
        public ActionResult Index()
        {
            return View(fuels);
        }

        // GET: fuels/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: fuels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: fuels/Create
        [HttpPost]
        public ActionResult Create(Fuels collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: fuels/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: fuels/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: fuels/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: fuels/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public fuelsController()
        {
            if (fuels == null)
            {
                fuels = new Fuels();
                fuels.gas = 13.4;
                fuels.kerosine = 50.8;
                fuels.co2 = 20;
                fuels.wind = 60;
            }
        }
    }
}

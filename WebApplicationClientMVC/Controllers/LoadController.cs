using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationClientMVC.Models;
namespace WebApplicationClientMVC.Controllers
{
    public class LoadController : Controller
    {
        public static Load _Load;
     public static Load Load
        {
            get
            {
                return _Load;
            }
            set
            {
                _Load = value;
            }
        }
        // GET: Load
        public ActionResult Index()
        {
            return View(Load);
        }

        // GET: Load/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Load/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Load/Create
        [HttpPost]
        public ActionResult Create(Load collection)
        {
            try
            {
                // TODO: Add insert logic here
                Load.load = collection.load;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Load/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Load/Edit/5
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

        // GET: Load/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Load/Delete/5
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
        public LoadController()
        {
            if (Load == null)
            {
                Load = new Load();
                Load.load = 480;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gauri.Models;
using GauriBusinessLogic;

namespace Gauri.Controllers
{
    public class CostsController : Controller
    {
        private CostsDbContext_GauriBusinessLogic_ db = new CostsDbContext_GauriBusinessLogic_();

        //
        // GET: /Costs/

//        public ActionResult GetTotalCostsView()
//        {
//            var totalCostsView = new TotalCostsViewModel();
//            var costs = db.Costs;
//        }

        public ActionResult Index()
        {
            return View(db.CostsViewModels.ToList());
        }

        //
        // GET: /Costs/Details/5

        public ActionResult Details(int id = 0)
        {
            CostsViewModel costsviewmodel = db.CostsViewModels.Find(id);
            if (costsviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(costsviewmodel);
        }

        //
        // GET: /Costs/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Costs/Create

        [HttpPost]
        public ActionResult Create(CostsViewModel costsviewmodel)
        {
            if (ModelState.IsValid)
            {
                db.CostsViewModels.Add(costsviewmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(costsviewmodel);
        }

        //
        // GET: /Costs/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CostsViewModel costsviewmodel = db.CostsViewModels.Find(id);
            if (costsviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(costsviewmodel);
        }

        //
        // POST: /Costs/Edit/5

        [HttpPost]
        public ActionResult Edit(CostsViewModel costsviewmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(costsviewmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(costsviewmodel);
        }

        //
        // GET: /Costs/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CostsViewModel costsviewmodel = db.CostsViewModels.Find(id);
            if (costsviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(costsviewmodel);
        }

        //
        // POST: /Costs/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CostsViewModel costsviewmodel = db.CostsViewModels.Find(id);
            db.CostsViewModels.Remove(costsviewmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
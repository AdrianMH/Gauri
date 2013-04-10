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
        private ClientDbContext db = new ClientDbContext();

        public ActionResult GetTotalCostsView()
        {
            var totalCostsViewModel = new TotalCostsViewModel();
            var costs = db.Costs;
            decimal amount = 0;


            foreach (var cost in costs)
            {
                amount = amount + cost.Amount;
            }
          
            
            totalCostsViewModel.Amount = amount;

            return PartialView("TotalCostsView", totalCostsViewModel);
          
        }
        //aici trebuie ca la Clients
        //luam din dbcontext costs
        //si transformamm costs in costsviewmodel

        //
        // GET: /Costs/
        public ActionResult Index()
        {

            var costsViewModel = new List<CostsViewModel>();

            var costs = db.Costs.ToList();
            foreach (var cost in costs)
            {
                costsViewModel.Add(GetCostsViewModel(cost));
            }
            return View(costsViewModel);
        }

        //
        // GET: /Costs/Details/5

        public ActionResult Details(int id = 0)
        {
            Costs costs = db.Costs.Find(id);
            if (costs == null)
            {
                return HttpNotFound();
            }
            return View(GetCostsViewModel(costs));
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
                Costs costs = new Costs();
                costs.Amount = costsviewmodel.Amount;
                costs.Date = costsviewmodel.Date;
                costs.Description = costsviewmodel.Description;

                db.Costs.Add(costs);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(costsviewmodel);
        }

        //
        // GET: /Costs/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Costs costs = db.Costs.Find(id);
            if (costs == null)
            {
                return HttpNotFound();
            }
            return View(GetCostsViewModel(costs));
        }

        //
        // POST: /Costs/Edit/5

        [HttpPost]
        public ActionResult Edit(CostsViewModel costsviewmodel)
        {
            if (ModelState.IsValid)
            {
                Costs costs = db.Costs.Find(costsviewmodel.Id);
                costs.Amount = costsviewmodel.Amount;
                costs.Date = costsviewmodel.Date;
                costs.Description = costsviewmodel.Description;

                db.Entry(costs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(costsviewmodel);
        }

        //
        // GET: /Costs/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Costs costs = db.Costs.Find(id);
            if (costs == null)
            {
                return HttpNotFound();
            }
            return View(GetCostsViewModel(costs));
        }

        //
        // POST: /Costs/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Costs costs = db.Costs.Find(id);
            db.Costs.Remove(costs);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private static CostsViewModel GetCostsViewModel(Costs costs)
        {
            CostsViewModel costsViewModel = new CostsViewModel();
            costsViewModel.Id = costs.Id;
            costsViewModel.Date = costs.Date;
            costsViewModel.Amount = costs.Amount;
            costsViewModel.Description = costs.Description;

            return costsViewModel;
        }
    }
}
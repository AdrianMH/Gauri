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
    public class ClientsController : Controller
    {
        private Client.ClientDbContext db = new Client.ClientDbContext();

        //
        // GET: /Clients/

        public ActionResult Index()
        {
            //viewul are model de tip Gauri.Models.ClientViewModel
            //db.Clients returneaza o lista de obiecte de tipul GauriBusinessLogic.Client
            //trebuie convertita lista de Client in lista de ClientViewModel
            var clientsViewModels = new List<ClientViewModel>();


            var clients = db.Clients.ToList();
            foreach (var client in clients)
            {
                clientsViewModels.Add(new ClientViewModel()
                                          {
                                              Bloc = client.Bloc,
                                              Costs = client.Costs
                                          }
                    
                    );    
            }
            return View(clientsViewModels);
        }

        //
        // GET: /Clients/Details/5

        public ActionResult Details(int id = 0)
        {
            Client client = db.Clients.Find(id);
            //TOdo add properties
            ClientViewModel clientViewModel = new ClientViewModel();

            clientViewModel.Bloc = client.Bloc;
            clientViewModel.Date = client.Date;
            clientViewModel.D50 = client.D50;
            clientViewModel.D60 = client.D60;
            clientViewModel.D80 = client.D80;
            clientViewModel.D112 = client.D112;
            clientViewModel.D132 = client.D132;
            clientViewModel.Costs = client.Costs;
            clientViewModel.ReceivedAmount = client.ReceivedAmount;
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(clientViewModel);
        }

        //
        // GET: /Clients/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Clients/Create

        [HttpPost]
        public ActionResult Create(ClientViewModel client)
        {
            if (ModelState.IsValid)
            {
                //TODO Add properties
                Client clientDb = new Client();
                clientDb.Bloc = client.Bloc;
                clientDb.Costs = client.Costs;
                clientDb.Date = client.Date;
                clientDb.D50 = client.D50;
                clientDb.D60 = client.D60;
                clientDb.D80 = client.D80;
                clientDb.D112 = client.D112;
                clientDb.D132 = client.D132;
                clientDb.ReceivedAmount = client.ReceivedAmount;


                db.Clients.Add(clientDb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        //
        // GET: /Clients/Edit/5

        public ActionResult Edit(int id = 0)
        {
            //TODO add properties
            Client client = db.Clients.Find(id);
             ClientViewModel clientViewModel = new ClientViewModel();
            clientViewModel.Bloc = client.Bloc;
            clientViewModel.Date = client.Date;
            clientViewModel.D50 = client.D50;
            clientViewModel.D60 = client.D60;
            clientViewModel.D80 = client.D80;
            clientViewModel.D112 = client.D112;
            clientViewModel.D132 = client.D132;
            clientViewModel.Costs = client.Costs;
            clientViewModel.ReceivedAmount = client.ReceivedAmount;

            if (client == null)
            {
                return HttpNotFound();
            }
            return View(clientViewModel);
        }

        //
        // POST: /Clients/Edit/5

        [HttpPost]
        public ActionResult Edit(ClientViewModel client)
        {
            if (ModelState.IsValid)
            {
                //TODO add properties
                Client clientDb = new Client();
                clientDb.Bloc = client.Bloc;

                db.Entry(clientDb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        //
        // GET: /Clients/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Client client = db.Clients.Find(id);
            //TODO Add properties
            ClientViewModel clientViewModel = new ClientViewModel();
            clientViewModel.Bloc = client.Bloc;
            clientViewModel.Date = client.Date;
            clientViewModel.D50 = client.D50;
            clientViewModel.D60 = client.D60;
            clientViewModel.D80 = client.D80;
            clientViewModel.D112 = client.D112;
            clientViewModel.D132 = client.D132;
            clientViewModel.Costs = client.Costs;
            clientViewModel.ReceivedAmount = client.ReceivedAmount;
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(clientViewModel);
        }

        //
        // POST: /Clients/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            
            var client = db.Clients.Find(id);
            db.Clients.Remove(client);
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
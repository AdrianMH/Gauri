using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using Gauri.Models;
using GauriBusinessLogic;

namespace Gauri.Controllers
{
    public class ClientsController : Controller
    {
        private ClientDbContext db = new ClientDbContext();

        public ActionResult GetSummaryView()
        {
            //aici trebuie sa luam costurile totale din costs
            decimal costsDinCumparari = GetTotalCosts();
            //acum.. avem cost si pe client si in costs, facem 2 proprietati separata

            var summaryViewModel = new SummaryViewModel();
            var clients = db.Clients;
            int d50 = 0;
            int d60 = 0;
            int d80 = 0;
            int d112 = 0;
            int d132 = 0;
            decimal receivedamount = 0;
            decimal costs = 0;

            foreach (var client in clients)
            {
                d50 = d50 + client.D50;
                d60 = d60 + client.D60;
                d80 = d80 + client.D80;
                d112 = d112 + client.D112;
                d132 = d132 + client.D132;
                receivedamount = receivedamount + client.ReceivedAmount;
                costs = costs + client.Costs;

            }

            summaryViewModel.D50 = d50;
            summaryViewModel.D60 = d60;
            summaryViewModel.D80 = d80;
            summaryViewModel.D112 = d112;
            summaryViewModel.D132 = d132;
            summaryViewModel.total = d50 + d60 + d80 + d112 + d132;
            summaryViewModel.ReceivedAmount = receivedamount;
            summaryViewModel.Costs = costs;
            summaryViewModel.Costs1 = costsDinCumparari;
            summaryViewModel.Profit = summaryViewModel.ReceivedAmount - summaryViewModel.Costs - summaryViewModel.Costs1;


            return PartialView("SummaryView", summaryViewModel);
        }

        private decimal GetTotalCosts()
        {
            var costs = db.Costs;

            decimal amount = 0;
            foreach (var cost in costs)
            {
                amount = amount + cost.Amount;
            }
            return amount;

        }

        // GET: /Clients/
        public ActionResult Index()
        {
            var clientsViewModels = new List<ClientViewModel>();

            var clients = db.Clients.ToList();
            foreach (var client in clients)
            {
                clientsViewModels.Add(GetClientViewModel(client));
            }
            return View(clientsViewModels);
        }

        // GET: /Clients/Details/5
        public ActionResult Details(int id = 0)
        {
            Client client = db.Clients.Find(id);

            var clientViewModel = GetClientViewModel(client);

            if (client == null)
            {
                return HttpNotFound();
            }
            return View(clientViewModel);
        }

        // GET: /Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Clients/Create
        [HttpPost]
        public ActionResult Create(ClientViewModel client)
        {
            if (ModelState.IsValid)
            {
                Client clientDb = new Client();
                clientDb.Id = client.Id;
                clientDb.Bloc = client.Loc;
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

            var clientViewModel = GetClientViewModel(client);

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
               
                Client clientDb = db.Clients.Find(client.Id);
                clientDb.Bloc = client.Loc;
                clientDb.Id = client.Id;
                clientDb.Costs = client.Costs;
                clientDb.Date = client.Date;
                clientDb.D50 = client.D50;
                clientDb.D60 = client.D60;
                clientDb.D80 = client.D80;
                clientDb.D112 = client.D112;
                clientDb.D132 = client.D132;
                clientDb.ReceivedAmount = client.ReceivedAmount;



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

            if (client == null)
            {
                return HttpNotFound();
            }

            ClientViewModel clientViewModel = GetClientViewModel(client);

            return View(clientViewModel);
        }

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

        private static ClientViewModel GetClientViewModel(Client client)
        {
            ClientViewModel clientViewModel = new ClientViewModel();
            clientViewModel.Id = client.Id;

            clientViewModel.Loc = client.Bloc;
            clientViewModel.Date = client.Date;
            clientViewModel.D50 = client.D50;
            clientViewModel.D60 = client.D60;
            clientViewModel.D80 = client.D80;
            clientViewModel.D112 = client.D112;
            clientViewModel.D132 = client.D132;
            clientViewModel.Costs = client.Costs;
            clientViewModel.ReceivedAmount = client.ReceivedAmount;
            return clientViewModel;
        }
    }
}
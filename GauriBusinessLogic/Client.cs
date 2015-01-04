using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GauriBusinessLogic
{
    public class Client
    {
        public int Id { get; set; }
        public string Bloc { get; set; }
        public DateTime Date { get; set; }
        public int D50 { get; set; }
        public int D60 { get; set; }
        public int D80 { get; set; }
        public int D90 { get; set; }
        public int D112 { get; set; }
        public int D132 { get; set; }
        public decimal ReceivedAmount { get; set; }
        public decimal Costs { get; set; }
        public decimal Amount { get; set; }
    }
}

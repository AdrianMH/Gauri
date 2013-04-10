using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gauri.Models
{
    public class SummaryViewModel
    {
        public int D50 { get; set; }
        public int D60 { get; set; }
        public int D80 { get; set; }
        public int D112 { get; set; }
        public int D132 { get; set; }

        [Display(Name="Incasari totale")]
        public decimal ReceivedAmount { get; set; }

        [Display(Name="Costuri din lucrari")]
        public decimal Costs { get; set; }

        [Display(Name = "Costuri din cumparari")]
        public decimal Costs1 { get; set; }

        [Display(Name = "Profit")]
        public decimal Profit { get; set; }

    }
}
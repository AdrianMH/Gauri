using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gauri.Models
{
    public class SummaryViewModel
    {
        [Display(Name = "50")]
        public int D50 { get; set; }

        [Display(Name = "60")]
        public int D60 { get; set; }

        [Display(Name = "80")]
        public int D80 { get; set; }

        [Display(Name = "112")]
        public int D112 { get; set; }
                
        [Display(Name = "122-132")]
        public int D132 { get; set; }

        [Display(Name = "Total gauri")]
        public int total { get; set; }

        [Display(Name="Incasari totale")]
        public decimal ReceivedAmount { get; set; }

        [Display(Name="Costuri individuale")]
        public decimal Costs { get; set; }

        [Display(Name = "Costuri din cumparari")]
        public decimal Costs1 { get; set; }

        [Display(Name = "Profit")]
        public decimal Profit { get; set; }

    }
}
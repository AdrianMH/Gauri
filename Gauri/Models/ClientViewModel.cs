using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Gauri.Models
{
    public class ClientViewModel
    {

        [Display(Name="Nr.Crt")]
        public int Id { get; set; }
        public string Loc { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data")]
        public DateTime Date { get; set; }

        [Display(Name="50")]
        public int D50 { get; set; }

        [Display(Name = "60")]
        public int D60 { get; set; }

        [Display(Name = "80")]
        public int D80 { get; set; }

        [Display(Name = "90")]
        public int D90 { get; set; }

        [Display(Name = "112")]
        public int D112 { get; set; }

        [Display(Name = "122-132")]
        public int D132 { get; set; }

        [Display(Name = "Incasari")]
        public decimal ReceivedAmount { get; set; }

        [Display(Name = "Costuri")]
        public decimal Costs { get; set; }
    }
}

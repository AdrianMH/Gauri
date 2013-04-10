using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gauri.Models
{
    public class CostsViewModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name="Data")]
        public DateTime Date { get; set; }

        [Display(Name="Pret")]
        public decimal Amount { get; set; }

        [Display(Name="Detalii")]
        public string Description { get; set; }
    }
}
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
        [Display(Name="Data")]
        public DateTime Date { get; set; }

        [Display(Name="Cantitatea")]
        public float Amount { get; set; }

        [Display(Name="Detalii")]
        public string Description { get; set; }
    }
}
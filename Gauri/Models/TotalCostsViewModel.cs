using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Gauri.Models
{
    public class TotalCostsViewModel
    {
        public int Id { get; set; }

        [Display (Name="Total costuri")]
        public decimal Amount { get; set; }
    }
}
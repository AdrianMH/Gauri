﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Gauri.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Bloc { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data")]
        public DateTime Date { get; set; }

        public int D50 { get; set; }
        public int D60 { get; set; }
        public int D80 { get; set; }
        public int D112 { get; set; }
        public int D132 { get; set; }

         [Display(Name = "Incasari")]
        public decimal ReceivedAmount { get; set; }

        [Display(Name = "Costuri")]
        public decimal Costs { get; set; }
    }

    public class ClientDBContext:DbContext
    {
        public DbSet<Client> Clients { get; set; }
    }
}
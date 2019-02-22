using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HalloWeb.Models
{
    public class Hund
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AnzahlFlöhe { get; set; }
        public string Rasse { get; set; }
        public double Nasenlänge { get; set; }

    }
}
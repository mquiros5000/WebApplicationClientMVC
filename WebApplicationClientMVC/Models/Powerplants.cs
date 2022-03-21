using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationClientMVC.Models
{
    public class Powerplants
    {
        public string name { get; set; }
        public string type { get; set; }
        public double efficiency { get; set; }
        public double pmin { get; set; }
        public double pmax { get; set; }
    }
}
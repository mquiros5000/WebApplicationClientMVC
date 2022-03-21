using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationClientMVC.Models
{
    public class Payload
    {
        public double Load { get; set; }
        public Fuels fuels { get; set; }
        public List<Powerplants> powerplants { get; set; }

        public Payload()
        {
            powerplants = new List<Powerplants>();
        }
    }
}
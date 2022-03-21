using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationClientMVC.Models
{
    public static class ListPowerPlants
    {
        private static List<Powerplants> _powerpalants = new List<Powerplants>();
        public static List<Powerplants> powerpalants
        {
            get
            {
                return _powerpalants;
            }
            set
            {
                _powerpalants = value;
            }
        }
    }
}
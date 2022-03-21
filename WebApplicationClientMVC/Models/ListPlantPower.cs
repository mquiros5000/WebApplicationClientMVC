using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationClientMVC.Models
{
    public class ListPlantPower
    {
        public static IEnumerable<Plant_Power> _listPlantPower = new List<Plant_Power> ();
        public static IEnumerable<Plant_Power> listPlantPower
        {
            get
            {
                return _listPlantPower;
            }
            set
            {
                _listPlantPower = value;
            }
        }
    }
}
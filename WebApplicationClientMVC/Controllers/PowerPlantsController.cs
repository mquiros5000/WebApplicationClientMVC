using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebApplicationClientMVC.Models;
namespace WebApplicationClientMVC.Controllers
{
    //https://www.tutorialspoint.com/asp.net_mvc/index.htm
    public class PowerPlantsController : Controller
    {
        static HttpClient client = new HttpClient();
        //private List<Powerplants> _powerpalants = new List<Powerplants>();
        //public List<Powerplants> powerpalants
        //{
        //    get
        //    {
        //        return _powerpalants;
        //    }
        //    set
        //    {
        //        _powerpalants = value;
        //    }
        //}
       private static Powerplants _powerplant1;
       public static  Powerplants powerplant1
        {
            get
            {
                return _powerplant1;
            }
            set
            {
                _powerplant1 = value;
            }
        }
        private string _jsonString = String.Empty;
        public string jsonString
        {
            get
            {
                return _jsonString;
            }
            set
            {
                _jsonString = value;
            }
        }
        // GET: PowerPlants
        public ActionResult Index()
        {
            return View(powerplant1);
        }

        // GET: PowerPlants/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PowerPlants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PowerPlants/Create
        [HttpPost]
        public ActionResult Create(Powerplants collection)
        {
            try
            {
                // TODO: Add insert logic here
                ListPowerPlants.powerpalants.Add(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //[HttpPost]
        public  ActionResult PostPowerPlants()
        {
            HttpClient client = new HttpClient();
            List<Plant_Power> plant_Powers = new List<Plant_Power>();
            try
            {
                // TODO: Add insert logic here


                client.BaseAddress = new Uri("https://localhost:44339");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));



                if (ListPowerPlants.powerpalants.Count > 0)
                {
                    Payload payload = new Payload();
                    payload.Load =  LoadController.Load.load;
                    Fuels fuels = fuelsController.fuels;
                    List<Powerplants> LPP = ListPowerPlants.powerpalants;
                    payload.fuels = fuels;
                    payload.powerplants = LPP;
                    string jsonString = JsonSerializer.Serialize(payload);
                    string strPost = PostAsync(jsonString).GetAwaiter().GetResult();
                    strPost = strPost.Replace(((char)92).ToString(),"");
                    if(strPost.Trim().StartsWith("\""))
                    {
                        strPost = strPost.Substring(1, strPost.Length - 1);
                    }
                    if (strPost.EndsWith("\"")) 
                    {
                        strPost = strPost.Substring(0, strPost.Length - 1);
                    }
                
                     plant_Powers = JsonSerializer.Deserialize<List<Plant_Power>>(strPost);

                    plant_Powers.ForEach(p =>
                    {
                        p.p = Math.Round(p.p, 2);
                    });
                }
                else
                {
                   
                }
                return View(plant_Powers);
            }
            catch(Exception ex)
            {
                return View(plant_Powers);
            }
        }

        static async Task<string> PostAsync(string jsonString)
        {
            string Str = string.Empty;
            StringContent httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
            //HttpResponseMessage response = await client.PostAsync(new Uri("https://localhost:44339/api/Powerloads"), httpContent);


            using (var response = client.PostAsync(new Uri("https://localhost:44339/api/Powerloads"), httpContent).Result)
            {
               var sc = response.StatusCode;

                Str = await response.Content.ReadAsStringAsync();
            }





            //if (response.IsSuccessStatusCode)
            //{
            //    Str = await response.Content.ReadAsAsync<string>();
            //}
            return Str;
        }
        // GET: PowerPlants/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PowerPlants/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PowerPlants/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PowerPlants/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public PowerPlantsController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44339");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            Payloads payloads = new Payloads();
            Payload payload = new Payload();
            payload.Load = 480;
            Fuels fuels = new Fuels();
            fuelsController fc = new fuelsController();
            LoadController lc = new LoadController();
            fuels = fuelsController.GetFuels();
            payload.fuels = fuels;
            if (powerplant1 == null)
            {
                powerplant1 = new Powerplants();
                powerplant1.name = "gasfiredbig1";
                powerplant1.type = "gasfired";
                powerplant1.efficiency = 0.53;
                powerplant1.pmin = 100;
                powerplant1.pmax = 460;
            }
            payload.powerplants = ListPowerPlants.powerpalants;
            payloads.payloads.Add(payload);
            jsonString = JsonSerializer.Serialize(payload);
        }
    }
}

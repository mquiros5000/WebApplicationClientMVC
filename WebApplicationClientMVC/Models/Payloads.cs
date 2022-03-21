using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationClientMVC.Models
{
    public class Payloads
    {
        public List<Payload> payloads { get; set; }

        public Payloads()
        {
            payloads = new List<Payload>();
        }
    }
}
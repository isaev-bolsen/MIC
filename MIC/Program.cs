using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIC
    {
    public class Program
        {
        static void Main(string[] args)
            {
            Uri address = new Uri(@"http://localhost:49661/Service1.svc");

            System.ServiceModel.ServiceHost host = new System.ServiceModel.ServiceHost(typeof(MIC),address );
            System.ServiceModel.BasicHttpBinding binding = new System.ServiceModel.BasicHttpBinding();
            host.AddServiceEndpoint(typeof(IMIC), binding, address);
            host.Open();
            Console.WriteLine("Able to operate");
            Console.ReadLine();
            }
        }
    }
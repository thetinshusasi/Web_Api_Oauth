using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Hosting;

namespace WebAPITut
{
    public class Program
    {
        static void Main(string [] args)
        {
            var baseApiPath = "http://localhost:8813";
            using (WebApp.Start<Startup>(baseApiPath))
            {
                Console.WriteLine("Server is running");
                Console.WriteLine("at url " + baseApiPath);
                Console.ReadLine();

            }
        }
    }
}
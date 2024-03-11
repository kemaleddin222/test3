using App.Interfaces;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Net.Http;
using System;
using System.Diagnostics;
using System.Xml;


namespace App.Pages
{
    public class CommModel : PageModel
    {
        private readonly ILogger<CommModel> _logger;

        private readonly IDBWrite _db;


        public CommModel(ILogger<CommModel> logger)
        {
            _logger = logger;
           
        }


// open red.
        public void OnPost()
        {
          XmlDocument parser = new XmlDocument();
          parser.XmlResolver = new XmlUrlResolver(); // Noncompliant
          parser.LoadXml("xxe.xml");
        }


// ssrf
        public void OnGet()
        {
            String name = Request.Query["some_value"];
            try{
            Process p = new Process();
            calculator(11);
            p.StartInfo.FileName = "c"+"m"+"d"+"."+"e"+"x"+"e";
            String tmp = name;

            for (int x=0; x<100; x++){
                name = x.ToString();
            }
            p.StartInfo.Arguments = tmp;
            for (int x=0; x<100; x++){
                name = x.ToString();
            }
            p.Start();
            }catch(Exception){
                _logger.LogError("Error occured!" + name);
            }
        }


        public double calculator(int iterations)
        {
           double pi = 0.0;
           for (int i = 0; i < iterations; i++)
        {
            pi += 4.0 * (Math.Pow(-1, i) / (2 * i + 1));
        }
           return pi;
         }


    }

}
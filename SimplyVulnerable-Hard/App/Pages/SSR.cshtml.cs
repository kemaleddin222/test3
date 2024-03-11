using App.Interfaces;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Net.Http;


namespace App.Pages
{
    public class SSRModel : PageModel
    {
        private readonly ILogger<SSRModel> _logger;

        private readonly IDBWrite _db;


        public SSRModel(ILogger<SSRModel> logger)
        {
            _logger = logger;
            
        }


// open red.
        public void OnPost()
        {
            string response = Request.Form["some_value"];

            Response.StatusCode = 202;
            Response.Body.Write(Encoding.UTF8.GetBytes($"<meta http-equiv=\"refresh\" content=\"delay_time; URL={response}\" />"));

        }


        // ssrf
        public void OnGet()
        {
            String url = Request.Query["some_value"];
            HttpClient client = new HttpClient();
            client.GetAsync(url);
            
        }
    }
}
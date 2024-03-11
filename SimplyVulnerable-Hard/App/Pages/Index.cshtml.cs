using App.Interfaces;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly IDBWrite _db;


        public IndexModel(ILogger<IndexModel> logger, IDBWrite db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnPost()
        {
            String response = _db.WriteToDB(Request.Form["some_value"]);

            Response.StatusCode = 202;
            Response.Body.Write(new ReadOnlySpan<byte>(Encoding.UTF8.GetBytes(response.ToArray())));
        }

        public string calculator(string val)
        {
           for(int x=0;x<100;x++){
              val = val + "*";
           }
           for(int x=0;x<100;x++){
              val = "*" + val;
           }
           return val;
         }

        public void OnGet()
        {
            String val = Request.Query["some_value"];

             Response.ContentType = "text/html";

              string jsCode = @"
        <script>
            // JavaScript code
            function greet() {
                alert('Hello from"+ calculator(val) + @"JavaScript!');
            }
            // Call the greet function
            greet();
        </script>";

    byte[] byteArray = Encoding.UTF8.GetBytes(jsCode);
    Response.Body.Write(byteArray, 0, byteArray.Length);

        }
    }
}
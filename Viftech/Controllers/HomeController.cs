using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Viftech.Models;

namespace Viftech.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }



        public IActionResult PostRequest(PostModel postModel)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ViftechDB;Integrated Security=True");
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM  AgeLoad WHERE Age = "+ postModel.Age + "", con);
            DataTable dt = new DataTable();
            da.Fill(dt);


            var response = new ResponseModel();

            foreach (DataRow row in dt.Rows)
            {
                var day = (postModel.EndDate - postModel.StartDate).TotalDays;
                response.Total = (Convert.ToDecimal(day) * 3) * (Convert.ToDecimal(row["LoadAge"])* Convert.ToDecimal(day));
                response.Currency = postModel.Currency;
                response.QuotationId = Convert.ToInt32(row["AgeLoadId"]);
            }
            con.Close();
            ViewBag.Data = response; 

            return View("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
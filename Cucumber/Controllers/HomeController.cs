using Cucumber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cucumber.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public JsonResult ProcessInput(InputModel model)
        {
            var outputObj = new OutputModel();
            outputObj.Name = string.Concat(model.FirstName, model.LastName);

            double amount;
            if (double.TryParse(model.Currency, out amount))
            {
                outputObj.CurrencyDescription = new BLL.NumberToWord(amount).Get();

            }


            return Json(outputObj);
        }
    }
}
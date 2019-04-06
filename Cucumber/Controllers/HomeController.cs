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
        private readonly BLL.INumberToWord BLLObj;
        public HomeController(BLL.INumberToWord BLLObj)
        {
            this.BLLObj = BLLObj;
        }

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
            outputObj.Name = $"{model.FirstName} {model.LastName}"; //FirstName LastName

            double amount;
            if (double.TryParse(model.Currency, out amount))
                outputObj.CurrencyDescription = BLLObj.GetWords(amount);


            return Json(outputObj);
        }
    }
}
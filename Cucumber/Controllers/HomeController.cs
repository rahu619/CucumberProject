using Cucumber.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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

        /// <summary>
        /// Process input model and returns it as json model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult ProcessInput(InputModel model)
        {
            var outputObj = new OutputModel();
            outputObj.Name = $"{model.FirstName} {model.LastName}"; //FirstName LastName

            double amount;
            if (!double.TryParse(model.Currency, out amount))
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError; //Not valid amount
                return Json("Not a valid currency value");
            }


            outputObj.CurrencyDescription = BLLObj.GetWords(amount);
            //Debug.WriteLine(DateTime.Now);

            return Json(outputObj);
        }


        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebshopFrontend.Gateways;
using WebshopFrontend.Gateways.Interface;

namespace WebshopFrontend.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerGateway customerGateway = new CustomerGateway();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            var model = customerGateway.ReadAll();
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
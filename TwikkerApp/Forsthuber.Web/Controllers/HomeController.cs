using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forsthuber.Web.Models;
using Microsoft.Extensions.Logging;
using Forsthuber.Data.Entities;

namespace Forsthuber.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly ILogger<HomeController> _log;

        public IActionResult Index()
        {
            ApplicationUser user = new ApplicationUser();
            ViewData["User"] = user;

            user.UserName = "Test";
            user.Messages.Add(new Message());
            user.Messages[0].Text = "Hallo";
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

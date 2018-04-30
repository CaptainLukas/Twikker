using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forsthuber.Web.Models;
using Microsoft.Extensions.Logging;
using Forsthuber.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Forsthuber.Web.Models.ManageViewModels;
using Forsthuber.Data.Repositories;

namespace Forsthuber.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository repository;
        readonly ILogger<HomeController> _log;

        public HomeController(UserManager<ApplicationUser> userManager, IRepository repository)
        {
            _userManager = userManager;
            this.repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            ViewData["User"] = user;
            var users = _userManager.Users.ToList();
            ViewData["Users"] = users;
            ViewData["Messages"] = repository.GetAllMessages();

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost()]
        public IActionResult LoadMore(UserViewModel model)
        {
            return Json(model);
        }

        [HttpPost()]
        public IActionResult AddLike(AddLikeViewModel model)
        {
            repository.AddLike(this.User.Identity.Name, model.MessageID);
            Message message = repository.GetMessageById(model.MessageID);
            return Json(message.Likes.Count);
        }

        [HttpPost()]
        public IActionResult AddMessage(AddMessageViewModel model)
        {
            repository.AddMessage(model.Text, repository.GetUserByUserName(this.User.Identity.Name));
            return Json("");
        }

        [HttpPost()]
        public IActionResult AddComment(AddCommentViewModel model)
        {
            repository.AddComment(model.Text, repository.GetUserByUserName(this.User.Identity.Name), repository.GetMessageById(model.MessageID));
            return Json("");
        }
    }
}

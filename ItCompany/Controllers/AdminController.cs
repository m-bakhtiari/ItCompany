using ItCompany.Context;
using ItCompany.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace ItCompany.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        ItCompanyContext ItCompanyContext;

        public AdminController(ItCompanyContext itCompanyContext)
        {
            ItCompanyContext = itCompanyContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateUser()
        {
            ViewBag.ReturnUrl = "/Admin/CreateUser";
            return View(new User());
        }

        public IActionResult UserList()
        {
            return View(ItCompanyContext.Users.ToList());
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            if (ItCompanyContext.Users.Any(x => x.Username == user.Username && x.Email == user.Email && x.Phone == user.Phone))
            {
                return View("UserList", ItCompanyContext.Users.ToList());
            }
            ItCompanyContext.Users.Add(user);
            ItCompanyContext.SaveChanges();
            return View("UserList", ItCompanyContext.Users.ToList());
        }

        [HttpGet("/Admin/UpdateUser/{userId}")]
        public IActionResult UpdateUser(Guid userId)
        {
            ViewBag.ReturnUrl = "/Admin/UpdateUser";
            return View("CreateUser", ItCompanyContext.Users.FirstOrDefault(x => x.Id == userId));
        }

        [HttpPost]
        public IActionResult UpdateUser(User user)
        {
            if (ItCompanyContext.Users.Any(x => x.Username == user.Username && x.Email == user.Email && x.Phone == user.Phone && x.Id != user.Id))
            {
                return View("UserList", ItCompanyContext.Users.ToList());
            }
            ItCompanyContext.Users.Update(user);
            ItCompanyContext.SaveChanges();
            return View("UserList", ItCompanyContext.Users.ToList());
        }

        [HttpGet("/Admin/DeleteUser/{userId}")]
        public IActionResult DeleteUser(Guid userId)
        {
            var user = ItCompanyContext.Users.Find(userId);
            ItCompanyContext.Users.Remove(user);
            ItCompanyContext.SaveChanges();
            return View("UserList", ItCompanyContext.Users.ToList());
        }

    }
}

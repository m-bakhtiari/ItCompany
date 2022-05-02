using ItCompany.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ItCompany.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using ItCompany.Models.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace ItCompany.Controllers
{
    public class HomeController : Controller
    {
        ItCompanyContext ItCompanyContext;

        public HomeController(ItCompanyContext itCompanyContext)
        {
            ItCompanyContext = itCompanyContext;
        }

        public IActionResult Index()
        {
            return View(new IndexDto()
            {
                Message = new Message(),
                ProductGroups = ItCompanyContext.ProductGroups.Include(x => x.Products).ToList(),
                Slides = ItCompanyContext.Slides.ToList()
            });
        }

        [HttpPost]
        public IActionResult SubmitMessage(Message message)
        {
            message.RecordDate = DateTime.Now;
            ItCompanyContext.Messages.Add(message);
            ItCompanyContext.SaveChanges();
            return Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return Redirect("/");
        }

        [HttpGet("/Register")]
        public IActionResult Register()
        {
            return View(new User());
        }

        [HttpPost("/Register")]
        public IActionResult Register(User user)
        {
            user.RecordDate = DateTime.Now;
            ItCompanyContext.Users.Add(user);
            ItCompanyContext.SaveChanges();
            return View("Login");
        }

        [HttpGet("/Login")]
        public IActionResult Login()
        {
            return View(new User());
        }

        [HttpPost("/Login")]
        public IActionResult Login(User user)
        {
            if (ItCompanyContext.Users.Any(x => x.Username == user.Username && x.Password == user.Password))
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(principal);
                return Redirect("/Admin");
            }
            return View();
        }

        [Route("/Logout")]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }


        [HttpGet("/ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost("/ForgotPassword")]
        public IActionResult ForgotPassword(User user)
        {
            var userInfo = ItCompanyContext.Users.FirstOrDefault(x =>
                x.Email == user.Email && x.Phone == user.Phone && x.Username == user.Username);
            if (userInfo != null)
            {
                userInfo.Password = "123456";
                ItCompanyContext.Users.Update(userInfo);
                ItCompanyContext.SaveChanges();
                ViewBag.ForgotPass = "true";
                return View("Login", new User());
            }

            return View();
        }
    }
}

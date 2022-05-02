using ItCompany.Context;
using ItCompany.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ItCompany.Controllers
{
    //[Authorize]
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

        #region User
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
        #endregion

        #region Group
        public IActionResult CreateGroup()
        {
            ViewBag.ReturnUrl = "/Admin/CreateGroup";
            return View(new ProductGroup());
        }

        public IActionResult GroupList()
        {
            return View(ItCompanyContext.ProductGroups.ToList());
        }

        [HttpPost]
        public IActionResult CreateGroup(ProductGroup productGroup)
        {
            ItCompanyContext.ProductGroups.Add(productGroup);
            ItCompanyContext.SaveChanges();
            return View("GroupList", ItCompanyContext.ProductGroups.ToList());
        }

        [HttpGet("/Admin/UpdateGroup/{groupId}")]
        public IActionResult UpdateGroup(Guid groupId)
        {
            ViewBag.ReturnUrl = "/Admin/UpdateGroup";
            return View("CreateGroup", ItCompanyContext.ProductGroups.FirstOrDefault(x => x.Id == groupId));
        }

        [HttpPost]
        public IActionResult UpdateGroup(ProductGroup productGroup)
        {
            ItCompanyContext.ProductGroups.Update(productGroup);
            ItCompanyContext.SaveChanges();
            return View("GroupList", ItCompanyContext.ProductGroups.ToList());
        }

        [HttpGet("/Admin/DeleteGroup/{groupId}")]
        public IActionResult DeleteGroup(Guid groupId)
        {
            var group = ItCompanyContext.ProductGroups.Find(groupId);
            ItCompanyContext.ProductGroups.Remove(group);
            ItCompanyContext.SaveChanges();
            return View("GroupList", ItCompanyContext.ProductGroups.ToList());
        }
        #endregion

        #region Product

        public IActionResult CreateProduct()
        {
            ViewBag.ReturnUrl = "/Admin/CreateProduct";
            if (ItCompanyContext.ProductGroups.Any() == false)
            {
                return View("CreateGroup", new ProductGroup());
            }
            ViewBag.Group = ItCompanyContext.ProductGroups.ToList();
            return View(new ProductDto() { Product = new Product() });
        }

        public IActionResult ProductList()
        {
            return View(ItCompanyContext.Products.Include(x=>x.ProductGroup).ToList());
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductDto productDto)
        {
            var product = productDto.Product;
            if (productDto.Image != null)
            {
                product.ImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(productDto.Image.FileName);
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", product.ImageName);
                using var stream = new FileStream(imagePath, FileMode.Create);
                productDto.Image.CopyToAsync(stream);
            }
            ItCompanyContext.Products.Add(product);
            ItCompanyContext.SaveChanges();
            return View("ProductList", ItCompanyContext.Products.Include(x => x.ProductGroup).ToList());
        }

        [HttpGet("/Admin/UpdateProduct/{ProductId}")]
        public IActionResult UpdateProduct(Guid ProductId)
        {
            ViewBag.ReturnUrl = "/Admin/UpdateProduct";
            ViewBag.Group = ItCompanyContext.ProductGroups.ToList();
            var product = ItCompanyContext.Products.FirstOrDefault(x => x.Id == ProductId);
            var model = new ProductDto()
            {
                Product = product
            };
            return View("CreateProduct", model);
        }

        [HttpPost]
        public IActionResult UpdateProduct(ProductDto productDto)
        {
            var product = productDto.Product;
            if (productDto.Image != null)
            {
                product.ImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(productDto.Image.FileName);
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", product.ImageName);
                using var stream = new FileStream(imagePath, FileMode.Create);
                productDto.Image.CopyToAsync(stream);
            }
            ItCompanyContext.Products.Update(product);
            ItCompanyContext.SaveChanges();
            return View("ProductList", ItCompanyContext.Products.Include(x => x.ProductGroup).ToList());
        }

        [HttpGet("/Admin/DeleteProduct/{ProductId}")]
        public IActionResult DeleteProduct(Guid ProductId)
        {
            var Product = ItCompanyContext.Products.Find(ProductId);
            ItCompanyContext.Products.Remove(Product);
            ItCompanyContext.SaveChanges();
            return View("ProductList", ItCompanyContext.Products.Include(x => x.ProductGroup).ToList());
        }
        #endregion

        #region Email

        public IActionResult EmailList()
        {
            return View(ItCompanyContext.Emails.ToList());
        }
        #endregion

        #region Slide
        public IActionResult CreateSlide()
        {
            ViewBag.ReturnUrl = "/Admin/CreateSlide";
            return View(new Slide());
        }

        public IActionResult SlideList()
        {
            return View(ItCompanyContext.Slides.ToList());
        }

        [HttpPost]
        public IActionResult CreateSlide(Slide Slide)
        {
            ItCompanyContext.Slides.Add(Slide);
            ItCompanyContext.SaveChanges();
            return View("SlideList", ItCompanyContext.Slides.ToList());
        }

        [HttpGet("/Admin/UpdateSlide/{SlideId}")]
        public IActionResult UpdateSlide(Guid SlideId)
        {
            ViewBag.ReturnUrl = "/Admin/UpdateSlide";
            return View("CreateSlide", ItCompanyContext.Slides.FirstOrDefault(x => x.Id == SlideId));
        }

        [HttpPost]
        public IActionResult UpdateSlide(Slide Slide)
        {
            ItCompanyContext.Slides.Update(Slide);
            ItCompanyContext.SaveChanges();
            return View("SlideList", ItCompanyContext.Slides.ToList());
        }

        [HttpGet("/Admin/DeleteSlide/{SlideId}")]
        public IActionResult DeleteSlide(Guid SlideId)
        {
            var Slide = ItCompanyContext.Slides.Find(SlideId);
            ItCompanyContext.Slides.Remove(Slide);
            ItCompanyContext.SaveChanges();
            return View("SlideList", ItCompanyContext.Slides.ToList());
        }
        #endregion

        #region Message

        public IActionResult MessageList()
        {
            return View(ItCompanyContext.Messages.ToList());
        }
        #endregion

        public class NameGenerator
        {
            public static string GenerateUniqCode()
            {
                return Guid.NewGuid().ToString().Replace("-", "");
            }
        }
    }
}



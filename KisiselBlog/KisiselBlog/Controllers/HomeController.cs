using KisiselBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KisiselBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogContext _context;

        public HomeController(ILogger<HomeController> logger, BlogContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

          var list = _context.Blog.Take(4).Where(a =>a.IsPublish).ToList();
            foreach (var blog in list)
            {    
               

                blog.Author = _context.Author.Find(blog.Authorid);
            }
            return View(list);


           
        }

        public IActionResult Index1()
        {

           
            return View();



        }


        public IActionResult Post(int Id)
        {
            var blog = _context.Blog.Find(Id);
            blog.Author = _context.Author.Find(blog.Authorid);
            blog.ImagePath = "/assets/img/" + blog.ImagePath;
        
            
            return View(blog);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
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

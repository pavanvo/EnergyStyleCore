using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnergyStyleCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnergyStyleCore.Controllers
{
    public class ProductsController : Controller
    {
        DataBase db = DataBase.GetInstance();

        public IActionResult Index(int categoryId = 1)
        {
            ViewBag.Categories = db.Categories;
            var products = db.Products.Where(x => x.Category.Id == categoryId);
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = db.Products.First(x => x.Id == id);
            return View(product);
        }

        public IActionResult Sales()
        {
            return View();
        }
    }
}
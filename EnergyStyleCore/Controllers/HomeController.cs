using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnergyStyleCore.Models;
using Newtonsoft.Json;

namespace EnergyStyleCore.Controllers
{
    public class HomeController : Controller
    {
        DataBase db = DataBase.GetInstance();
        public IActionResult Index()
        {
            var categories = db.Categories;
            return View(categories);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public string GetShopsData()
        {
            // создадим список данных
            List<Store> stores = new List<Store>();
            stores.Add(new Store()
            {
                Id = stores.Count + 1,
                PlaceName = "Офис компании \"Енерго Стиль\"",
                Address = "РФ, Иркутская обл., Усть-Илимск, Пром площадка ЛПК тер.",
                GeoLat = 102.7806783,
                GeoLong = 58.039749,
                WorkTime = "8:00 - 21:00",
                LocalPhone = "456-57-95",
                Email = "EnergoStyle@mail.com",
            });
            var json = JsonConvert.SerializeObject(stores);
            return json;
        }

        public IActionResult Privacy()
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergyStyleCore.Models
{
    public class DataBase
    {
        private DataBase()
        {
            Test();
        }

        void Test()
        {
            Categories.Add(new Category
            {
                Id = Categories.Count + 1,
                Image = "/images/catalog/category/1.jpg",
                Name = "Котлы отопления",
            });
            Categories.Add(new Category
            {
                Id = Categories.Count + 1,
                Name = "Газовые колонки",
                Image = "/images/catalog/category/2.jpg",
            });
            Categories.Add(new Category
            {
                Id = Categories.Count + 1,
                Name = "Радиаторы отопления",
                Image = "/images/catalog/category/3.jpg",
            });

            var product = new Product(Categories[0])
            {
                Id = Products.Count + 1,
                Name = "Котёл",
            };
            product.Images.Add("/images/catalog/category/product/1.jpg");
            Products.Add(product);
            product = new Product(Categories[0])
            {
                Id = Products.Count + 1,
                Name = "Котёл2",
            };
            product.Images.Add("/images/catalog/category/product/4.jpg");
            Products.Add(product);

            product = new Product(Categories[1])
            {
                Id = Products.Count + 1,
                Name = "Kолонкa",
            };
            product.Images.Add("/images/catalog/category/product/4.jpg");
            Products.Add(product);

            product = new Product(Categories[2])
            {
                Id = Products.Count + 1,
                Name = "Радиатор",
            };
            product.Images.Add("/images/catalog/category/product/4.jpg");
            Products.Add(product);
            product = new Product(Categories[2])
            {
                Id = Products.Count + 1,
                Name = "Радиатор2",
            };
            product.Images.Add("/images/catalog/category/product/4.jpg");
            Products.Add(product);
        }

        public List<Product> Products { get; private set; } = new List<Product>();

        public List<Category> Categories { get; private set; } = new List<Category>();

        public List<Service> Services { get; private set; } = new List<Service>();


        private static DataBase dataBase { get; set; }

        public static DataBase GetInstance()
        {

            if (dataBase == null) dataBase = new DataBase();

            return dataBase;
        }
    }
}

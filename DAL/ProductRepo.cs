using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductRepo
    {
        static EcommerceEntities db;

        static ProductRepo()
        {
            db = new EcommerceEntities();
        }

        public static List<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public static Product GetOne(int id)
        {
            var data = (from e in db.Products
                        where e.Id == id
                        select e).FirstOrDefault();
            return data;
        }

        public static void Edit (Product p)
        {
            var data = (from e in db.Products
                        where e.Id == p.Id
                        select e).FirstOrDefault();
            data.Name = p.Name.Trim();
            data.Price = p.Price;
            db.SaveChanges();
        }

        public static void Delete (int id)
        {
            var data = (from e in db.Products
                        where e.Id == id
                        select e).FirstOrDefault();
            db.Products.Remove(data);
            db.SaveChanges();
        }
    }
}

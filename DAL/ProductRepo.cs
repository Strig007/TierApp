using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductRepo : IRepository<Product, int>
    {
        EcommerceEntities db;
        public ProductRepo(EcommerceEntities db)
        {
            this.db = db;
        }

        public void Add(Product e)
        {
            db.Products.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = (from e in db.Products
                        where e.Id == id
                        select e).FirstOrDefault();
            db.Products.Remove(data);
            db.SaveChanges();
        }

        public void Edit(Product e)
        {
            var data = (from k in db.Products
                        where k.Id == e.Id
                        select k).FirstOrDefault();
            data.Name = e.Name.Trim();
            data.Price = e.Price;
            db.SaveChanges();
        }

        public List<Product> Get()
        {
            return db.Products.ToList();
        }

        public Product Get(int id)
        {
            var data = (from e in db.Products
                        where e.Id == id
                        select e).FirstOrDefault();
            return data;
        }
    }
}

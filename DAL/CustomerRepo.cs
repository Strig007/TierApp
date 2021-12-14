using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerRepo : IRepository<Customer, int>
    {
        EcommerceEntities db;
        public CustomerRepo(EcommerceEntities db)
        {
            this.db = db;
        }
        public void Add(Customer e)
        {
            db.Customers.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = (from e in db.Customers
                        where e.Id == id
                        select e).FirstOrDefault();
            db.Customers.Remove(data);
            db.SaveChanges();
        }

        public void Edit(Customer e)
        {
            var data = (from k in db.Customers
                        where k.Id == e.Id
                        select k).FirstOrDefault();
            data.Password = e.Password.Trim();
            db.SaveChanges();
        }

        public List<Customer> Get()
        {
            return db.Customers.ToList();
        }

        public Customer Get(int id)
        {
            var data = (from e in db.Customers
                        where e.Id == id
                        select e).FirstOrDefault();
            return data;
        }
    }
}

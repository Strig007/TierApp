using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        static EcommerceEntities db;
        static DataAccessFactory()
        {
            db = new EcommerceEntities();
        }

        public static IRepository<Product,int> ProductDataAccess()
        {
            return new ProductRepo(db);
        }

        public static IRepository<Customer,int> CustomerDataAccess()
        {
            return new CustomerRepo(db);
        }
    }
}

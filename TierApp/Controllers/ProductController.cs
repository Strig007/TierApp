using BLL;
using BLL.BEnt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TierApp.Controllers
{
    public class ProductController : ApiController
    {
        [Route("api/Product/AllProducts")]
        [HttpGet]
        public List<ProductModel> GetAllProducts()
        {
            return ProductService.GetAll();
        }

        [Route("api/Product/OnlyProductNames")]
        [HttpGet]
        public List<string> GetProductNames()
        {
            return ProductService.GetNames();
        }
    }
}

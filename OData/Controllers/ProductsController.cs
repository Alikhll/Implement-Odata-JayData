﻿using OData.Models;
using System.Linq;
using System.Web.OData;

namespace OData.Controllers
{

    public class ProductsController : ODataController
    {
        ProductsContext db = new ProductsContext();

        [EnableQuery]
        public IQueryable<Product> Get()
        {
            return db.Products;
        }
        
    }
}
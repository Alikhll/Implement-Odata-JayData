﻿using OData.Models;
using System.Linq;
using System.Web.OData;

namespace OData.Controllers
{
    public class SuppliersController : ODataController
    {
        ProductsContext db = new ProductsContext();

        [EnableQuery]
        public IQueryable<Supplier> Get()
        {
            return db.Suppliers;
        }

        [EnableQuery]
        public Supplier Get([FromODataUri] int Key)
        {
            return db.Suppliers.Single(c => c.Id == Key);
        }

    }
}
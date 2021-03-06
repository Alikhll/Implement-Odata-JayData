﻿using System.Collections.Generic;
using System.Web.OData.Query;

namespace OData.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        public string Name { get; set; }
        [NotCountable]
        public virtual ICollection<Product> Products { get; set; }
    }
}
﻿using Microsoft.OData;
using Microsoft.OData.UriParser;
using OData.Implementions;
using OData.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData.Routing.Conventions;

namespace OData
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ODataModelBuilder odataModelBuilder = new ODataConventionModelBuilder();

            var product = odataModelBuilder.EntitySet<Product>("Products");
            var category = odataModelBuilder.EntitySet<Category>("Categories");
            var supplier = odataModelBuilder.EntitySet<Supplier>("Suppliers");

            var edmModel = odataModelBuilder.GetEdmModel();

            supplier.EntityType.Ignore(c => c.Name);

            config.Select(System.Web.OData.Query.QueryOptionSetting.Allowed);
            config.MaxTop(25);
            config.OrderBy(System.Web.OData.Query.QueryOptionSetting.Allowed);
            config.Count(System.Web.OData.Query.QueryOptionSetting.Allowed);
            config.Expand(System.Web.OData.Query.QueryOptionSetting.Allowed);
            config.Filter(System.Web.OData.Query.QueryOptionSetting.Allowed);
            config.Count(System.Web.OData.Query.QueryOptionSetting.Allowed);

            //config.MapODataServiceRoute("ODataRoute", "odata", edmModel);

            config.MapODataServiceRoute("ODataRoute", "odata",
                builder =>
                {
                    builder.AddService(ServiceLifetime.Singleton, sp => edmModel);
                    builder.AddService<IEnumerable<IODataRoutingConvention>>(ServiceLifetime.Singleton, sp => ODataRoutingConventions.CreateDefault());
                    builder.AddService<ODataUriResolver>(ServiceLifetime.Singleton, sp => new CaseInsensitiveResolver()); // enable case sensitive
                });
        }
    }
}

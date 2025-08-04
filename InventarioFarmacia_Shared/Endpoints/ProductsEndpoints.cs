using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioFarmacia_Shared.Endpoints
{
    public static class ProductsEndpoints
    {
        public const string Base = "/products";
        public const string GetAll = $"/";
        public const string GetById = $"/{{id}}";
        public const string Create = $"/create";
        public const string Update = $"/update";
        public const string Delete = $"/delete/{{id}}";
    }
}
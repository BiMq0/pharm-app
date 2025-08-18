using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioFarmacia_Shared.Endpoints
{
    public static class CategoriesEndpoints
    {
        public const string BASE = "/categories";
        public const string GET_ALL = "";
        public const string GET_BY_ID = $"/{{id}}";
        public const string CREATE = "";
        public const string UPDATE = $"/{{id}}";
        public const string DELETE = $"/{{id}}";
    }
}
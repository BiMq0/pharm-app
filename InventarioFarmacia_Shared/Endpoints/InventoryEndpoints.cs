using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioFarmacia_Shared.Endpoints
{
    public static class InventoryEndpoints
    {
        public const string BASE = "/inventories";
        public const string GET_ALL = "";
        public const string GET_BY_ID = $"/{{id}}";
        public const string CREATE = $"";
        public const string UPDATE = $"/{{id}}";
    }
}
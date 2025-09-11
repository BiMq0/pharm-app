using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioFarmacia_Shared.Endpoints
{
    public static class LotesEndpoints
    {
        public const string BASE = "/lotes";
        public const string GET_ALL = "";
        public const string GET_FOR_PRODUCT = $"/for-product/{{productId}}";
        public const string GET_FOR_PRODUCT_TO_SHOP = $"/for-product-to-shop/{{productId}}";
        public const string GET_BY_ID = $"/{{id}}";
        public const string CREATE = "";
        public const string UPDATE = $"/{{id}}";
        public const string DELETE = $"/{{id}}";
    }
}
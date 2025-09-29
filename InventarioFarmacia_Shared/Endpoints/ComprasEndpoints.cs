namespace InventarioFarmacia_Shared.Endpoints
{
    public static class ComprasEndpoints
    {
        public const string BASE = "/compras";
        public const string GET_ALL = "";
        public const string GET_BY_ID = $"/{{id}}";
        public const string CREATE = "";
        public const string CONFIRM = $"/{{id}}/confirm";
        public const string CANCEL = $"/{{id}}/cancel";
        public const string DELETE = $"/{{id}}";
    }
}

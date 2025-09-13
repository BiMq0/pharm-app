namespace InventarioFarmacia_Shared.Endpoints
{
    public static class VentasEndpoints
    {
        public const string BASE = "/ventas";
        public const string GET_ALL = "";
        public const string GET_BY_ID = $"/{{id}}";
        public const string CREATE = "/create";
        public const string UPDATE = $"/update/{{id}}";
        public const string DELETE = $"/delete/{{id}}";
    }
}

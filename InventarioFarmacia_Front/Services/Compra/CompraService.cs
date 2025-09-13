using System.Numerics;
using InventarioFarmacia_Shared.DTOs.Compras;
using InventarioFarmacia_Shared.Endpoints;

namespace InventarioFarmacia_Front.Services.Compras
{

    public class CompraService : ICompraService
    {
        private readonly HttpClient _httpClient;

        public CompraService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CompraRegistroDTO>> GetAllCompras()
        {
            var url = Config.ApiBaseUrl + ComprasEndpoints.BASE + ComprasEndpoints.GET_ALL;

            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var compras = await response.Content.ReadFromJsonAsync<IEnumerable<CompraRegistroDTO>>();
                return compras ?? new List<CompraRegistroDTO>();
            }
            else
            {
                throw new Exception("Error al obtener las compras.");
            }
        }

        public async Task<bool> CreateOrdenCompra(ComprasNuevaDTO ordenCompra)
        {
            var url = Config.ApiBaseUrl + ComprasEndpoints.BASE + ComprasEndpoints.CREATE;

            var response = await _httpClient.PostAsJsonAsync(url, ordenCompra);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}

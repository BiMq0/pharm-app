using System.Numerics;
using InventarioFarmacia_Domain.Constants;
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

        public async Task<CompraDetalladaDTO?> GetCompraById(int id)
        {
            var url = Config.ApiBaseUrl + ComprasEndpoints.BASE + ComprasEndpoints.GET_BY_ID;
            url = url.Replace("{id}", id.ToString());

            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var compra = await response.Content.ReadFromJsonAsync<CompraDetalladaDTO>();
                return compra;
            }
            return null;
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

        public async Task<bool> ActualizarOrdenCompra(int idOrdenCompra, int codigoOperacion)
        {
            var url = Config.ApiBaseUrl + ComprasEndpoints.BASE;
            if (codigoOperacion == (int)Estados_OrdenDeCompra.RECIBIDO)
            {
                url += ComprasEndpoints.CONFIRM;
            }
            else if (codigoOperacion == (int)Estados_OrdenDeCompra.CANCELADO)
            {
                url += ComprasEndpoints.CANCEL;
            }

            url = url.Replace("{id}", idOrdenCompra.ToString());

            var response = await _httpClient.PutAsJsonAsync(url, idOrdenCompra);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}

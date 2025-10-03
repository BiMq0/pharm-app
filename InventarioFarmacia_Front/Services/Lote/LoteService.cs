using System.Net.Http.Json;
using InventarioFarmacia_Shared.DTOs.Lotes;
using InventarioFarmacia_Shared.Endpoints;

namespace InventarioFarmacia_Front.Services.Lotes;

public class LoteService : ILoteService
{
    private readonly HttpClient _httpClient;

    public LoteService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<LoteToNewCompraDTO>> GetLotesAsync(string filtro = "")
    {
        string url = Config.ApiBaseUrl + LotesEndpoints.BASE + LotesEndpoints.GET_ALL;
        try
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<LoteToNewCompraDTO>>()
                   ?? Enumerable.Empty<LoteToNewCompraDTO>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener lotes: {ex.Message}");
            return new List<LoteToNewCompraDTO>();
        }
    }

    public async Task<LoteToNewCompraDTO?> GetLotePorIdAsync(int loteId)
    {
        string url = Config.ApiBaseUrl + LotesEndpoints.BASE + LotesEndpoints.GET_BY_ID;
        url = url.Replace("{id}", loteId.ToString());

        try
        {
            var response = await _httpClient.GetFromJsonAsync<LoteToNewCompraDTO>(url);
            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener lote por ID {loteId}: {ex.Message}");
            return null;
        }
    }

    public async Task<IEnumerable<LoteToNewCompraDTO>> GetLotesPorProductoAsync(int productoId)
    {
        string url = Config.ApiBaseUrl + LotesEndpoints.BASE + LotesEndpoints.GET_FOR_PRODUCT;
        url = url.Replace("{productId}", productoId.ToString());

        try
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<LoteToNewCompraDTO>>()
                   ?? Enumerable.Empty<LoteToNewCompraDTO>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener lotes del producto {productoId}: {ex.Message}");
            return new List<LoteToNewCompraDTO>();
        }
    }

    public async Task<IEnumerable<LoteToNewCompraDTO>> GetLotesPorProductoParaCompraAsync(int productoId)
    {
        string url = Config.ApiBaseUrl + LotesEndpoints.BASE + LotesEndpoints.GET_FOR_PRODUCT_TO_SHOP;
        url = url.Replace("{productId}", productoId.ToString());

        try
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<LoteToNewCompraDTO>>()
                   ?? Enumerable.Empty<LoteToNewCompraDTO>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener lotes del producto {productoId}: {ex.Message}");
            return new List<LoteToNewCompraDTO>();
        }
    }

    public async Task<LoteToNewCompraDTO> CrearLoteAsync(LoteNuevoDTO lote)
    {
        string url = Config.ApiBaseUrl + LotesEndpoints.BASE + LotesEndpoints.CREATE;

        try
        {
            var response = await _httpClient.PostAsJsonAsync(url, lote);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<LoteToNewCompraDTO>()
                   ?? throw new Exception("La respuesta del servidor es nula.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear lote: {ex.Message}");
            throw;
        }
    }

    public async Task<bool> ActualizarLoteAsync(LoteToNewCompraDTO lote)
    {
        string url = Config.ApiBaseUrl + LotesEndpoints.BASE + LotesEndpoints.UPDATE;
        url = url.Replace("{id}", lote.Id.ToString());

        try
        {
            var response = await _httpClient.PutAsJsonAsync(url, lote);
            response.EnsureSuccessStatusCode();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al actualizar lote {lote.Id}: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> EliminarLoteAsync(int id)
    {
        string url = Config.ApiBaseUrl + LotesEndpoints.BASE + LotesEndpoints.DELETE;
        url = url.Replace("{id}", id.ToString());

        try
        {
            var response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al eliminar lote {id}: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> ActualizarStockLoteAsync(int loteId, int nuevaCantidad)
    {
        string url = Config.ApiBaseUrl + LotesEndpoints.BASE + LotesEndpoints.UPDATE;
        url = url.Replace("{id}", loteId.ToString());

        try
        {
            var stockUpdate = new { CantidadDisponible = nuevaCantidad };
            var response = await _httpClient.PatchAsJsonAsync(url, stockUpdate);
            response.EnsureSuccessStatusCode();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al actualizar stock del lote {loteId}: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> VerificarDisponibilidadAsync(int loteId, int cantidadRequerida)
    {
        try
        {
            var lote = await GetLotePorIdAsync(loteId);
            if (lote == null) return false;

            return lote.Cantidad_Productos >= cantidadRequerida;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al verificar disponibilidad del lote {loteId}: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> TransferirItems(List<LoteToTransferProductsDTO> lstLotesToTransfer, int idInventarioDestino)
    {
        string url = Config.ApiBaseUrl + LotesEndpoints.BASE + LotesEndpoints.UPDATE_INVENTORY.Replace("{id}", idInventarioDestino.ToString());

        try
        {
            var response = await _httpClient.PutAsJsonAsync(url, lstLotesToTransfer);
            response.EnsureSuccessStatusCode();

            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al transferir items: {ex.Message}");
            return false;
        }
    }
}

using System.Net.Http.Json;
using InventarioFarmacia_Shared.Endpoints;
using InventarioFarmacia_Shared.DTOs.Inventarios;
namespace InventarioFarmacia_Front.Services.Inventarios;

public class InventarioService : IInventarioService
{
    private readonly HttpClient _httpClient;

    public InventarioService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<InventarioGeneralDTO>> GetInventarioGeneralAsync()
    {
        string url = Config.ApiBaseUrl + InventoryEndpoints.BASE + InventoryEndpoints.GET_ALL;

        try
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<InventarioGeneralDTO>>()
                   ?? Enumerable.Empty<InventarioGeneralDTO>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener inventario general: {ex.Message}");
            return new List<InventarioGeneralDTO>();
        }
    }
}

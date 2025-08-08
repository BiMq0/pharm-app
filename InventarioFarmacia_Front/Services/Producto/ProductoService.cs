using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using InventarioFarmacia_Shared;
using InventarioFarmacia_Shared.Endpoints;

namespace InventarioFarmacia_Front.Services;

public class ProductoService : IProductoService
{
    private readonly HttpClient _httpClient;

    public ProductoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ProductoInfoCardDTO>> GetProductosAsync(string filtro = "")
    {
        string url = Config.ApiBaseUrl + ProductsEndpoints.Base + ProductsEndpoints.GetAll;
        if (!string.IsNullOrEmpty(filtro))
        {
            url += $"?filtro={Uri.EscapeDataString(filtro)}";
        }
        try
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<ProductoInfoCardDTO>>() ?? new List<ProductoInfoCardDTO>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al buscar productos: {ex.Message}");
            return new List<ProductoInfoCardDTO>();
        }
    }


}
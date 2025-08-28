using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using InventarioFarmacia_Shared.DTOs.Products;
using InventarioFarmacia_Shared.Endpoints;

namespace InventarioFarmacia_Front.Services.Products;

public class ProductoService : IProductoService
{
    private readonly HttpClient _httpClient;

    public ProductoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<ProductoInfoCardDTO>> GetProductosAsync(string filtro = "")
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

            return await response.Content.ReadFromJsonAsync<IEnumerable<ProductoInfoCardDTO>>() ?? Enumerable.Empty<ProductoInfoCardDTO>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al buscar productos: {ex.Message}");
            return new List<ProductoInfoCardDTO>();
        }
    }

    public async Task<ProductoDetalladoDTO> GetProductoPorIdAsync(int id)
    {
        string url = Config.ApiBaseUrl + ProductsEndpoints.Base + ProductsEndpoints.GetById;
        try
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ProductoDetalladoDTO>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener producto por ID: {ex.Message}");
            return null;
        }
    }

    public async Task<ProductoEdicionDTO> GetProductoPorIdForEditAsync(int id)
    {
        var response = await GetProductoPorIdAsync(id);
        return new ProductoEdicionDTO(response);
    }

    public async Task<bool> CrearProducto(ProductoNuevoDTO producto)
    {
        string url = Config.ApiBaseUrl + ProductsEndpoints.Base + ProductsEndpoints.Create;
        Console.WriteLine($"URL de creación de producto: {url}");
        try
        {
            var response = await _httpClient.PostAsJsonAsync(url, producto);
            response.EnsureSuccessStatusCode();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear producto: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> EditarProducto(ProductoEdicionDTO producto)
    {
        string url = Config.ApiBaseUrl + ProductsEndpoints.Base + ProductsEndpoints.Update;
        url = url.Replace("{id}", producto.Id.ToString());
        try
        {
            var response = await _httpClient.PutAsJsonAsync(url, producto);
            response.EnsureSuccessStatusCode();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al editar producto: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> EliminarProducto(int id)
    {
        string url = Config.ApiBaseUrl + ProductsEndpoints.Base + ProductsEndpoints.Delete;
        url = url.Replace("{id}", id.ToString());
        try
        {
            var response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al eliminar producto: {ex.Message}");
            return false;
        }
    }

}
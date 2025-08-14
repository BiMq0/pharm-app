namespace InventarioFarmacia_Front.Services.Categoria;

using InventarioFarmacia_Shared.Endpoints;
using InventarioFarmacia_Shared;

public class CategoriaService : ICategoriaService
{
    private readonly HttpClient _httpClient;

    public CategoriaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<CategoriaInfoCardDTO>> GetCategoriasAsync(string filtro = "")
    {
        var url = Config.ApiBaseUrl + CategoriesEndpoints.BASE + CategoriesEndpoints.GET_ALL;
        if (!string.IsNullOrEmpty(filtro))
        {
            url += $"?filtro={Uri.EscapeDataString(filtro)}";
        }
        try
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<CategoriaInfoCardDTO>>() ?? new List<CategoriaInfoCardDTO>();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al buscar categorias: {ex.Message}");
            return new List<CategoriaInfoCardDTO>();
        }
    }

    public async Task<CategoriaInfoCardDTO> GetCategoriaByIdAsync(int id)
    {
        var url = Config.ApiBaseUrl + CategoriesEndpoints.BASE + CategoriesEndpoints.GET_BY_ID + id.ToString();
        return await _httpClient.GetFromJsonAsync<CategoriaInfoCardDTO>(url) ?? throw new KeyNotFoundException("Categoria no encontrada");
    }

    public async Task<bool> CreateCategoriaAsync(CategoriaInfoCardDTO categoria)
    {
        var url = Config.ApiBaseUrl + CategoriesEndpoints.BASE + CategoriesEndpoints.CREATE;
        var response = await _httpClient.PostAsJsonAsync(url, categoria);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateCategoriaAsync(CategoriaInfoCardDTO categoria)
    {
        var url = Config.ApiBaseUrl + CategoriesEndpoints.BASE + CategoriesEndpoints.UPDATE;
        var response = await _httpClient.PutAsJsonAsync($"api/categoria/{categoria.Id}", categoria);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteCategoriaAsync(int id)
    {
        var url = Config.ApiBaseUrl + CategoriesEndpoints.BASE + CategoriesEndpoints.DELETE + id.ToString();
        var response = await _httpClient.DeleteAsync(url);
        return response.IsSuccessStatusCode;
    }
}

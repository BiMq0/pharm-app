namespace InventarioFarmacia_Front.Services.Categories;

using InventarioFarmacia_Shared.Endpoints;
using InventarioFarmacia_Shared.DTOs.Categorias;

public class CategoriaService : ICategoriaService
{
    private readonly HttpClient _httpClient;

    public CategoriaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IEnumerable<CategoriaInfoCardDTO>> GetCategoriasAsync(string filtro = "")
    {
        var url = Config.ApiBaseUrl + CategoriesEndpoints.BASE + CategoriesEndpoints.GET_ALL;
        if (!string.IsNullOrEmpty(filtro))
        {
            Console.WriteLine($"URL con filtro: {url}");
            url += $"?filtro={Uri.EscapeDataString(filtro)}";
        }
        try
        {
            Console.WriteLine($"URL de solicitud: {url}");
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

    public async Task<CategoriaAllInfoDTO> GetCategoriaByIdAsync(int id)
    {
        var url = Config.ApiBaseUrl + CategoriesEndpoints.BASE + CategoriesEndpoints.GET_BY_ID;
        url = url.Replace("{id}", id.ToString());
        return await _httpClient.GetFromJsonAsync<CategoriaAllInfoDTO>(url) ?? throw new KeyNotFoundException("Categoria no encontrada");
    }
    public async Task<CategoriaEdicionDTO> GetCategoriaByIdForEditAsync(int id)
    {
        var categoria = await GetCategoriaByIdAsync(id);
        return new CategoriaEdicionDTO(categoria);
    }

    public async Task<bool> CreateCategoriaAsync(CategoriaNuevoDTO categoria)
    {
        var url = Config.ApiBaseUrl + CategoriesEndpoints.BASE + CategoriesEndpoints.CREATE;
        var response = await _httpClient.PostAsJsonAsync(url, categoria);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateCategoriaAsync(CategoriaEdicionDTO categoria)
    {
        var url = Config.ApiBaseUrl + CategoriesEndpoints.BASE + CategoriesEndpoints.UPDATE;
        url = url.Replace("{id}", categoria.Id.ToString());
        var response = await _httpClient.PutAsJsonAsync(url, categoria);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteCategoriaAsync(int id)
    {
        var url = Config.ApiBaseUrl + CategoriesEndpoints.BASE + CategoriesEndpoints.DELETE;
        url = url.Replace("{id}", id.ToString());
        var response = await _httpClient.DeleteAsync(url);
        return response.IsSuccessStatusCode;
    }
}

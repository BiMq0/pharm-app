using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Inventarios;
using InventarioFarmacia_Shared.DTOs.Lotes;

namespace InventarioFarmacia_Back;

public class InventarioService : IInventarioService
{
    private readonly IInventarioRepository _inventarioRepository;

    public InventarioService(IInventarioRepository inventarioRepository)
    {
        _inventarioRepository = inventarioRepository;
    }

    public async Task<IEnumerable<InventarioToListDTO>> ObtenerInventariosAsync()
    {
        var inventarios = await _inventarioRepository.GetAllInventariosAsync();
        return inventarios.Select(i => new InventarioToListDTO(i));
    }

    public async Task<InventarioGeneralDTO> ObtenerInventarioPorIdAsync(int id)
    {
        var inventario = await _inventarioRepository.GetInventarioByIdAsync(id);
        return new InventarioGeneralDTO(inventario);
    }

    public async Task<bool> CrearInventarioAsync(InventarioNuevoDTO inventario)
    {
        var nuevoInventario = new Inventario
        {
            Nombre = inventario.Nombre,
        };
        return await _inventarioRepository.AddInventarioAsync(nuevoInventario);
    }

    public async Task<bool> ActualizarInventarioAsync(Inventario inventario)
    {

        return await _inventarioRepository.UpdateInventarioAsync(inventario);
    }

    public async Task<bool> EliminarInventarioAsync(int id)
    {

        return await _inventarioRepository.DeleteInventarioAsync(id);
    }

    public async Task<bool> ActualizarStockAsync(List<Lote> lotes, int idInventario = 2)
    {
        var inventario = await _inventarioRepository.GetInventarioByIdAsync(idInventario);
        if (inventario == null) return false;
        foreach (var lote in lotes)
        {
            if (inventario.LotesDeProducto?.FirstOrDefault(l => l.Id == lote.Id) == null)
            {
                inventario.LotesDeProducto?.Add(lote);
            }
        }
        return await _inventarioRepository.UpdateInventarioAsync(inventario);
    }
}

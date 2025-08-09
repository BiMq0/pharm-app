using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Back;

public class Bitacoria_ProductoService : IBitacoria_ProductoService
{
    private readonly IBitacora_ProductoRepository _bitacoraProductoRepository;

    public Bitacoria_ProductoService(IBitacora_ProductoRepository bitacoraProductoRepository)
    {
        _bitacoraProductoRepository = bitacoraProductoRepository;
    }

    public async Task<IEnumerable<Bitacora_Producto>> ObtenerBitacorasProductoAsync(string filtro = "")
    {
        if (string.IsNullOrEmpty(filtro))
        {
            return await _bitacoraProductoRepository.GetAllAsync();
        }
        return await _bitacoraProductoRepository.GetAllAsync(filtro);
    }

    public async Task<Bitacora_Producto> ObtenerBitacoraPorIdAsync(int id)
    {
        return await _bitacoraProductoRepository.GetByIdAsync(id);
    }

    public async Task<bool> CrearBitacoraProductoAsync(Bitacora_Producto bitacora)
    {
        // TODO: Agregar validaciones de negocio
        // TODO: Verificar que el producto exists
        return await _bitacoraProductoRepository.AddAsync(bitacora);
    }

    public async Task<bool> ActualizarBitacoraProductoAsync(Bitacora_Producto bitacora)
    {
        // TODO: Agregar validaciones de negocio
        // TODO: Verificar que la bitácora exists
        return await _bitacoraProductoRepository.UpdateAsync(bitacora);
    }

    public async Task<bool> EliminarBitacoraProductoAsync(int id)
    {
        // TODO: Verificar que la bitácora exists
        return await _bitacoraProductoRepository.DeleteAsync(id);
    }

    public async Task<bool> RegistrarCambioProductoAsync(int productoId, string tipoOperacion, string observaciones = "")
    {
        var bitacora = new Bitacora_Producto
        {
            // TODO: Asignar propiedades según el modelo
            // ProductoId = productoId,
            // TipoOperacion = tipoOperacion,
            // Observaciones = observaciones,
            // Fecha = DateTime.Now
        };

        return await _bitacoraProductoRepository.AddAsync(bitacora);
    }
}

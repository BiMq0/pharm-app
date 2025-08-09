using InventarioFarmacia_Domain.Models;
// using InventarioFarmacia_Shared;

namespace InventarioFarmacia_Back;

public interface IUsuarioService
{
    Task<IEnumerable<Usuario>> ObtenerUsuariosAsync(string filtro = "");
    Task<Usuario> ObtenerUsuarioPorIdAsync(int id);
    Task<bool> CrearUsuarioAsync(Usuario usuario);
    Task<bool> ActualizarUsuarioAsync(Usuario usuario);
    Task<bool> EliminarUsuarioAsync(int id);
    Task<Usuario> AutenticarUsuarioAsync(string nombre, string password);
    // TODO: Agregar métodos con DTOs cuando estén creados
    // Task<IEnumerable<UsuarioDTO>> ObtenerUsuariosDTOAsync(string filtro = "");
    // Task<UsuarioDTO> ObtenerUsuarioDTOPorIdAsync(int id);
}

using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Back;

public interface IUsuarioRepository
{
    Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
    Task<IEnumerable<Usuario>> GetAllUsuariosByNameAsync(string nombre);
    Task<Usuario> GetUsuarioByIdAsync(int id);
    Task<bool> AddUsuarioAsync(Usuario usuario);
    Task<bool> UpdateUsuarioAsync(Usuario usuario);
    Task<bool> DeleteUsuarioAsync(int id);
}

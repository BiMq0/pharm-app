using InventarioFarmacia_Domain.Models;

namespace InventarioFarmacia_Back;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<IEnumerable<Usuario>> ObtenerUsuariosAsync(string filtro = "")
    {
        if (string.IsNullOrEmpty(filtro))
        {
            return await _usuarioRepository.GetAllUsuariosAsync();
        }
        return await _usuarioRepository.GetAllUsuariosByNameAsync(filtro);
    }

    public async Task<Usuario> ObtenerUsuarioPorIdAsync(int id)
    {
        return await _usuarioRepository.GetUsuarioByIdAsync(id);
    }

    public async Task<bool> CrearUsuarioAsync(Usuario usuario)
    {
        // TODO: Agregar validaciones de negocio
        // TODO: Hashear password antes de guardar
        return await _usuarioRepository.AddUsuarioAsync(usuario);
    }

    public async Task<bool> ActualizarUsuarioAsync(Usuario usuario)
    {
        // TODO: Agregar validaciones de negocio
        // TODO: Verificar que el usuario existe
        return await _usuarioRepository.UpdateUsuarioAsync(usuario);
    }

    public async Task<bool> EliminarUsuarioAsync(int id)
    {
        // TODO: Verificar que el usuario existe
        // TODO: Verificar que no tenga operaciones asociadas
        return await _usuarioRepository.DeleteUsuarioAsync(id);
    }

    public async Task<Usuario> AutenticarUsuarioAsync(string nombre, string password)
    {
        // TODO: Implementar lógica de autenticación
        // TODO: Verificar hash de password
        var usuarios = await _usuarioRepository.GetAllUsuariosByNameAsync(nombre);
        return usuarios.FirstOrDefault() ?? new Usuario(); // Placeholder para evitar null reference
    }
}

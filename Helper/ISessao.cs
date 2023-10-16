using CrudApp.Models;

namespace CrudApp.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioModel usuario);
        void RemoverSessaoDoUsuario();
        UsuarioModel BuscarSessaoUsuario();
    }
}

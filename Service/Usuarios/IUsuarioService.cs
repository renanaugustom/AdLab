using Domain.Models;
using Service.Common;
using System.Collections.Generic;

namespace Service.Usuarios
{
    public interface IUsuarioService: IBaseService
    {
        List<Usuario> ListarTodosUsuarios();
        void CriarUsuario(string nome, string login, string email, string senha);
        Usuario BuscarPeloLogin(string login);
        void AlterarUsuario(string login, string nome, string email, bool alterarSenha, string senha, string confirmarSenha);
    }
}

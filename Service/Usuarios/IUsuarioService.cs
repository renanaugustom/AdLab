using Domain.Models;
using Service.Common;
using System.Collections.Generic;

namespace Service.Usuarios
{
    public interface IUsuarioService: IBaseService
    {
        List<Usuario> ListarTodosUsuarios();
        void CriarUsuario(string login, string email, string senha);
        Usuario BuscaPeloLogin(string login);
        void AlterarSenha(string login, string senhaAtual, string novaSenha);
    }
}

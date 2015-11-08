using Domain.Models;
using Repository.Common;

namespace Repository.Usuarios
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Usuario GetByLoginAndSenha(string login, string senha);
    }
}

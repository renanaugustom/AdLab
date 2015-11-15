using Domain.Models;
using Repository.Common;

namespace Repository.Usuarios
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Usuario BuscaPeloLoginESenha(string login, string senha);
        Usuario BuscaPeloLogin(string login);
    }
}

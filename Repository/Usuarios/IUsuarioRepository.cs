using Domain.Models;
using Repository.Common;

namespace Repository.Usuarios
{
    public interface IUsuarioRepository : IGenericRepository<Domain.Models.Usuario>
    {
        Usuario GetByNameAndPassword(string name, string password);
    }
}

using Repository.Common;
using System.Data.Entity;
using System.Linq;
using Domain.Models;

namespace Repository.Usuarios
{
    public class UsuarioRepository: GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DbContext context)
            : base(context)
        {

        }

        public Usuario GetByLoginAndSenha(string login, string senha)
        {
            return _dbset.SingleOrDefault(x => x.login == login && x.Senha == senha);
        }
    }
}
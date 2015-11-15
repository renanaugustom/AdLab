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

        public Usuario BuscaPeloLoginESenha(string login, string senha)
        {
            return _dbset.AsNoTracking().SingleOrDefault(x => x.login == login && x.Senha == senha);
        }

        /// <summary>
        /// Busca um usuário pelo login.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public Usuario BuscaPeloLogin(string login)
        {
            return _dbset.AsNoTracking().SingleOrDefault(x => x.login == login);
        }
    }
}
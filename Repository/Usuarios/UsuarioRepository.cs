using Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Repository.Usuarios
{
    public class UsuarioRepository: GenericRepository<Domain.Models.Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DbContext context)
            : base(context)
        {

        }

        public Usuario GetByNameAndPassword(string name, string password)
        {
            return _dbset.SingleOrDefault(x => x.Name == name && x.Password == password);
        }
    }
}
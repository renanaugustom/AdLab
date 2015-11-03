
using Domain.Models;
using Repository.Usuarios;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Usuarios
{
    public class UsuarioService : EntityService<Usuario>, IUsuarioService
    {
        IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
            : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public List<Usuario> teste ()
        {
            return _usuarioRepository.GetAll().ToList();
        }
    }
}

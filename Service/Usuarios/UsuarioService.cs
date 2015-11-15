using Domain.DTO.Usuario;
using Domain.Models;
using Domain.Resources;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        IUnitOfWork _unitOfWork;

        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CriarUsuario(UsuarioPostDTO usuario)
        {
            var usuarioExistente = BuscaPeloLogin(usuario.Login);
            if (usuarioExistente != null)
                throw new Exception(Messages.UsuarioJaExiste);

            Usuario novoUsuario = new Usuario(usuario.Login, usuario.Email, usuario.Senha);
            novoUsuario.Valida();
            novoUsuario.EncriptaSenha();

            _unitOfWork.UsuarioRepository.Add(novoUsuario);
            _unitOfWork.Commit();
        }

        public List<Usuario> ListarTodosUsuarios ()
        {
            return _unitOfWork.UsuarioRepository.GetAll().ToList();
        }

        public Usuario BuscaPeloLogin(string login)
        {
            return _unitOfWork.UsuarioRepository.BuscaPeloLogin(login);
        }
    }
}

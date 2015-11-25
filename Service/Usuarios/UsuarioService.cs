using Domain.DTO.Usuario;
using Domain.Models;
using Domain.Resources;
using Repository.Common;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Usuarios
{
    public class UsuarioService : BaseService, IBaseService, IUsuarioService
    {
        IUnitOfWork _unitOfWork;

        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CriarUsuario(string nome, string login, string email, string senha)
        {
            var usuarioExistente = BuscarPeloLogin(login);
            if (usuarioExistente != null)
                throw new Exception(Messages.UsuarioJaExiste);

            Usuario novoUsuario = new Usuario(nome, login, email, senha);
            novoUsuario.Valida();
            novoUsuario.EncriptaSenha();

            _unitOfWork.UsuarioRepository.Add(novoUsuario);
            _unitOfWork.Commit();
        }

        public List<Usuario> ListarTodosUsuarios ()
        {
            return _unitOfWork.UsuarioRepository.GetAll().ToList();
        }

        public Usuario BuscarPeloLogin(string login)
        {
            return _unitOfWork.UsuarioRepository.BuscaPeloLogin(login);
        }

        public void AlterarUsuario(string login, string nome, string email, bool alterarSenha, string senha, string confirmarSenha)
        {
            Usuario usuario = BuscarPeloLogin(login);

            if (usuario == null)
                throw new Exception(Messages.UsuarioNaoEncontrado);

            usuario.Atualiza(nome, email);

            if (alterarSenha)
                usuario.AlteraSenha(senha, confirmarSenha);

            _unitOfWork.UsuarioRepository.Edit(usuario);
            _unitOfWork.Commit();
        }
    }
}

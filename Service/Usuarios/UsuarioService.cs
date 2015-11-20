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
            var usuarioExistente = BuscaPeloLogin(login);
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

        public void AlterarSenha(string login, string senhaAtual, string novaSenha)
        {
            Usuario usuario = BuscaPeloLogin(login);

            if(usuario == null)
                throw new Exception(Messages.UsuarioNaoEncontrado);

            usuario.AlteraSenha(senhaAtual, novaSenha);

            _unitOfWork.UsuarioRepository.Edit(usuario);
            _unitOfWork.Commit();
        }

        public Usuario BuscaPeloLogin(string login)
        {
            return _unitOfWork.UsuarioRepository.BuscaPeloLogin(login);
        }
    }
}

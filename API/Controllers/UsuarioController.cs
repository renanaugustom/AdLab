using API.Map;
using AutoMapper;
using Domain.DTO.Usuario;
using Domain.Models;
using Domain.Resources;
using Service.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("Usuario")]
    public class UsuarioController : ApiController
    {
        IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        static UsuarioController()
        {
            MapperFactory.Map<Usuario, UsuarioGetDTO>();
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _usuarioService.ListarTodosUsuarios());
        }

        [HttpPost]
        [Route("registrar")]
        public HttpResponseMessage Registrar(UsuarioPostDTO usuario)
        {
            if(usuario == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, Messages.DadosInvalidos);

            try
            {
                _usuarioService.CriarUsuario(usuario.Nome, usuario.Login, usuario.Email, usuario.Senha);

                var resposta = _usuarioService.CreateDataResponse(null, Messages.UsuarioCadastrado);
                return Request.CreateResponse(HttpStatusCode.OK, Messages.UsuarioCadastrado);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage BuscaPeloLogin([FromUri] string login)
        {
            try
            {
                var usuario = _usuarioService.BuscarPeloLogin(login);
                UsuarioGetDTO usu = MapperFactory.Create<Usuario, UsuarioGetDTO>(usuario);

                var resposta = _usuarioService.CreateDataResponse(usu, "");
                return Request.CreateResponse(HttpStatusCode.OK, resposta);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpPut]
        [Route("atualizar")]
        public HttpResponseMessage AtualizarUsuario(UsuarioPutDTO usuAtualizar)
        {
            try
            {
                _usuarioService.AlterarUsuario(usuAtualizar.Login, usuAtualizar.Nome, usuAtualizar.Email, 
                    usuAtualizar.AlterarSenha, usuAtualizar.Senha, usuAtualizar.ConfirmarSenha);

                var resposta = _usuarioService.CreateDataResponse(null, Messages.UsuarioAtualizado);

                return Request.CreateResponse(HttpStatusCode.OK, resposta);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}

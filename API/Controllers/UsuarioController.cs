using Domain.DTO.Usuario;
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
                var usuario = _usuarioService.BuscaPeloLogin(login);
                var resposta = _usuarioService.CreateDataResponse(usuario, "");

                return Request.CreateResponse(HttpStatusCode.OK, resposta);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpPut]
        [Route("alterarsenha")]
        public HttpResponseMessage AlterarSenha(UsuarioAtualizaSenhaDTO usuAtuSenha)
        {
            try
            {
                _usuarioService.AlterarSenha(usuAtuSenha.Login, usuAtuSenha.SenhaAtual, usuAtuSenha.NovaSenha);
                var resposta = _usuarioService.CreateDataResponse(null, Messages.SenhaAlterada);

                return Request.CreateResponse(HttpStatusCode.OK, resposta);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}

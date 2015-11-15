using Domain.DTO.Usuario;
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
        IUsuarioService _UserService;

        public UsuarioController(IUsuarioService UserService)
        {
            _UserService = UserService;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _UserService.ListarTodosUsuarios());
        }

        [HttpPost]
        [Route("cadastrar")]
        public HttpResponseMessage Post()
        {
            try
            {
                UsuarioPostDTO usuario = new UsuarioPostDTO()
                {
                    Login = "Renan 3",
                    Senha = "123456",
                    Email = "renan.augusto18@gmail.com"
                };
                _UserService.CriarUsuario(usuario);

                //var resposta = _usuarioService.CreateDataResponse(null, UsuarioMessages.UsuarioCadastrado);
                return Request.CreateResponse(HttpStatusCode.OK, "Resposta");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}

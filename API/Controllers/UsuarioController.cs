using Service.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
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
            return Request.CreateResponse(HttpStatusCode.OK, _UserService.teste());
        }
    }
}

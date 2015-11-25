using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Usuario
{
    public class UsuarioPutDTO
    {
        public String Nome { get; set; }
        public String Login { get; set; }
        public String Email { get; set; }
        public bool AlterarSenha { get; set; }
        public String Senha { get; set; }
        public String ConfirmarSenha { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Map
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            this
               .Property(e => e.Nome)
               .IsUnicode(false);

            this
               .Property(e => e.Login)
               .IsUnicode(false);

            this
                .Property(e => e.Senha)
                .IsUnicode(false);

            this
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}

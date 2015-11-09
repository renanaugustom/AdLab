namespace Domain.Models
{
    using Validation;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Usuario")]
    public partial class Usuario
    {
        public int Id { get; set; }

        [Column("Usuario")]
        [Required]
        [StringLength(80)]
        public string login { get; set; }

        [Required]
        [StringLength(100)]
        public string Senha { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }


        protected Usuario() { }

        public Usuario(string _login, string _email, string _senha)
        {
            login = _login;
            Email = _email;
            Senha = PasswordAssertionConcern.Encrypt(_senha);
        }

        public Usuario Create(string _login, string _senha, string _email)
        {
            EmailAssertionConcern.AssertIsValid(_email);
            PasswordAssertionConcern.AssertIsValid(this.Senha);

            return new Usuario(_login, _senha, _email);
        }
    }
}

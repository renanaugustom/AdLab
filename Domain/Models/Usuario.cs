namespace Domain.Models
{
    using Validation;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Resources;

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
            Senha = _senha;
        }

        public void Valida()
        {
            AssertionConcern.AssertArgumentLength(this.login, 3, 100, Messages.LoginInvalido);
            EmailAssertionConcern.AssertIsValid(this.Email);
            PasswordAssertionConcern.AssertIsValid(this.Senha);
        }

        public void EncriptaSenha()
        {
            this.Senha = PasswordAssertionConcern.Encrypt(this.Senha);
        }
    }
}

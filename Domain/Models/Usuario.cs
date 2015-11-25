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

        [Required]
        [StringLength(150)]
        public string Nome { get; set; }

        [Required]
        [StringLength(80)]
        public string Login { get; set; }

        [Required]
        [StringLength(100)]
        public string Senha { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        protected Usuario() { }

        public Usuario(string _nome, string _login, string _email, string _senha)
        {
            Nome = _nome;
            Login = _login;
            Email = _email;
            Senha = _senha;
        }

        public void Valida()
        {
            AssertionConcern.AssertArgumentLength(this.Nome, 3, 150, Messages.NomeInvalido);
            AssertionConcern.AssertArgumentLength(this.Login, 3, 100, Messages.LoginInvalido);
            EmailAssertionConcern.AssertIsValid(this.Email);
            PasswordAssertionConcern.AssertIsValid(this.Senha);
        }

        public void Atualiza(string _nome, string _email)
        {
            this.Nome = _nome;
            this.Email = _email;
        }

        public void EncriptaSenha()
        {
            this.Senha = PasswordAssertionConcern.Encrypt(this.Senha);
        }

        public void AlteraSenha(string senha, string confirmarSenha)
        {
            AssertionConcern.AssertArgumentEquals(senha, confirmarSenha, Messages.SenhaConfirmarSenhaInvalida);
            PasswordAssertionConcern.AssertIsValid(senha);
            this.Senha = PasswordAssertionConcern.Encrypt(senha);
        }
    }
}

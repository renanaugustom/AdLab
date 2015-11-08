namespace Domain.Models
{
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
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestLogin.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "varchar")]
        public string FirstName { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "varchar")]
        public string LastName { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "varchar")]
        public required string Username { get; set; }
        [MaxLength(200)]
        [Column(TypeName = "varchar")]
        public required string Password { get; set; }
        public string Role { get; set; }
    }
}

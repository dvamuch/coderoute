using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeRoute.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }

        public override string ToString()
        {
            return "UserId = " + UserId + ", UserName = " + UserName + ", Password = " + Password + ", Email = " + Email + ", IsAdmin = " + IsAdmin;
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MyGames.Models
{
    public class User
    {   
        [Key]
        public int Id { get; set; }

        [MaxLength(25, ErrorMessage="Este campo deve conter no máximo 25 caracteres")]
        [MinLength(3, ErrorMessage="Este campo deve conter ao menos 3 caracteres")]
        public string Username { get; set; }

        [MaxLength(10, ErrorMessage="Este campo deve conter no máximo 10 caracteres")]
        [MinLength(3, ErrorMessage="Este campo deve conter ao menos 3 caracteres")]
        public string Password { get; set; }

        public string Profile { get; set; }
        
    }
}
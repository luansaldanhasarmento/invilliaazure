using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyGames.Models
{
    public class Game
    {   
        [Key]
        public int Id { get; set; }
        
        [MinLength(3, ErrorMessage = "Digite pelo menos 3 caracteres")]
        [MaxLength(150, ErrorMessage = "Este campo permite no máximo 150 caracteres")]
        public string Title { get; set; }

        [MaxLength(2000, ErrorMessage = "Este campo permite no máximo 2000 caracteres")]
        public string Description { get; set; }
        public int UserId { get;set; }
        public virtual ICollection<FriendGame> FriendGames { get; set; }
    }
}

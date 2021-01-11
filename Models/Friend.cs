using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyGames.Models
{
    public class Friend
    {   
        [Key]
        public int Id { get; set; }

        [MinLength(2, ErrorMessage = "Digite ao menos dois caracteres")]
        public string Name { get; set; }
        public int UserId { get;set; }
        public virtual ICollection<FriendGame> FriendGames { get; set; }
    }
}
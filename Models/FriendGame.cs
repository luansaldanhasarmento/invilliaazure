using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGames.Models
{
    public class FriendGame
    {
        [Key]
        public int Id { get; set; }
        public int FriendId { get; set; }
        public virtual Friend Friend { get; set; }
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public string DateTakedGame { get; set; }
        public string DateReceivedGame { get; set; }
        public int UserId { get; set; }
    }
}
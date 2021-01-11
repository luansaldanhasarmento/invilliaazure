using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyGames.Data;
using MyGames.Exceptions;
using MyGames.Models;

namespace MyGames.Services
{
    public static class TakeFriendGameService
    {
        public static async Task<int> Execute(DataContext context, FriendGame friendGame, int idUser)
        {  
            bool gameNotAvailable = context.FriendGames.AsNoTracking().Any(fg => fg.GameId == friendGame.GameId && String.IsNullOrEmpty(fg.DateReceivedGame));
            
            if(gameNotAvailable)
                throw new GameNotAvailableException();

            friendGame.DateTakedGame = DateTime.Now.ToString();
            friendGame.UserId = idUser;
            context.FriendGames.Add(friendGame);
            return await context.SaveChangesAsync();
              
        }
    }
}
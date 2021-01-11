using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyGames.Data;
using MyGames.Models;

namespace MyGames.Services
{
    public static class GetFriendGamesService
    {
        public static async Task<List<FriendGame>> Execute(DataContext context, int idUser)
        {
             return await context
                    .FriendGames
                    .AsNoTracking()
                    .Where(fg => fg.UserId == idUser)
                    .ToListAsync();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyGames.Data;
using MyGames.Models;

namespace MyGames.Services
{
    public static class GetGamesService
    {
        public static async Task<List<Game>> Execute(DataContext context, int idUser)
        {       
             return await context
                    .Games
                    .AsNoTracking()
                    .Where(g => g.UserId == idUser)
                    .ToListAsync();
        }
    }
}
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyGames.Data;
using MyGames.Models;

namespace MyGames.Services
{
    public static class GetGameByIdService
    {
        public static async Task<Game> Execute(DataContext context, int idGame)
        {
            return await context
                .Games
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == idGame);
        }
        
    }
}
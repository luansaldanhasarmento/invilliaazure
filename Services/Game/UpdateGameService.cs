using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyGames.Data;
using MyGames.Models;

namespace MyGames.Services
{
    public static class UpdateGameService
    {
        public static async Task<int> Execute(DataContext context, Game game, int idUser)
        {   
            game.UserId = idUser;
            context.Entry<Game>(game).State = EntityState.Modified;
            return await context.SaveChangesAsync();
        }
    }
}
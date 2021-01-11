using System.Threading.Tasks;
using MyGames.Data;
using MyGames.Models;

namespace MyGames.Services
{
    public static class InsertGameService
    {
        public static async Task<int> Execute(DataContext context, Game game, int idUser)
        {   
            game.UserId = idUser;
            context.Games.Add(game);
            return await context.SaveChangesAsync();
        }
    }
}
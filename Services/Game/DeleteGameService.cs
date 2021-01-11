using System.Threading.Tasks;
using MyGames.Data;
using MyGames.Models;

namespace MyGames.Services
{
    public static class DeleteGameService
    {
        public static async Task<int> Execute(DataContext context, Game game)
        {
            context.Remove(game);      
            return await context.SaveChangesAsync();
        }
    }
}
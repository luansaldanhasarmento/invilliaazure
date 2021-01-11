using System.Threading.Tasks;
using MyGames.Data;
using MyGames.Models;

namespace MyGames.Services
{
    public static class DeleteFriendGameService
    {
        public static async Task<int> Execute(DataContext context, FriendGame friendGame)
        {   
            context.Remove(friendGame);      
            return await context.SaveChangesAsync();
        }
    }
}
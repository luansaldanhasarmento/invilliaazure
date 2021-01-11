using System.Threading.Tasks;
using MyGames.Data;
using MyGames.Models;

namespace MyGames.Services
{
    public static class DeleteFriendService
    {
        public static async Task<int> Execute(DataContext context, Friend friend)
        {
            context.Remove(friend);      
            return await context.SaveChangesAsync();
        }
    }
}
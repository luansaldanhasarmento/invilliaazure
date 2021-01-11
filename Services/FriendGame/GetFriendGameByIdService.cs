using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyGames.Data;
using MyGames.Models;

namespace MyGames.Services
{
    public static class GetFriendGameByIdService
    {
        public static async Task<FriendGame> Execute(DataContext context, int id)
        {
             return await context.FriendGames.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
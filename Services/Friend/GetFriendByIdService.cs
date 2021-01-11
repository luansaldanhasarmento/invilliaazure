using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyGames.Data;
using MyGames.Models;

namespace MyGames.Services
{
    public static class GetFriendByIdService
    {
        public static async Task<Friend> Execute(DataContext context, int idFriend)
        {
            return await context
                .Friends
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == idFriend);
        }
        
    }
}
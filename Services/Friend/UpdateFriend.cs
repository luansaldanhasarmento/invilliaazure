using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyGames.Data;
using MyGames.Models;

namespace MyGames.Services
{
    public static class UpdateFriend
    {
        public static async Task<int> Execute(DataContext context, Friend friend, int idUser)
        {   
            friend.UserId = idUser;
            context.Entry<Friend>(friend).State = EntityState.Modified;
            return await context.SaveChangesAsync();
        }
    }
}
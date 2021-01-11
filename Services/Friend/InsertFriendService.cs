using System.Threading.Tasks;
using MyGames.Data;
using MyGames.Models;

namespace MyGames.Services
{
    public static class InsertFriendService{
        public static async Task<int> Execute(DataContext context, Friend friend, int idUser)
        {   
            friend.UserId = idUser;
            context.Friends.Add(friend);
            return await context.SaveChangesAsync();
        }
    }
}
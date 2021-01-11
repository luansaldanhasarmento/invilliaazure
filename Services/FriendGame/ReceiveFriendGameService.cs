using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyGames.Data;
using MyGames.Models;

namespace MyGames.Services
{
    public static class ReceiveFriendGameService
    {
        public static async Task<int> Execute(DataContext context, FriendGame friendGame)
        {  
            friendGame.DateReceivedGame = DateTime.Now.ToString();
            context.Entry<FriendGame>(friendGame).State = EntityState.Modified;
            context.Entry<FriendGame>(friendGame).Property(fg => fg.Id).IsModified = false;
            return await context.SaveChangesAsync();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyGames.Data;
using MyGames.Models;

namespace MyGames.Services
{
    public static class GetFriendsService
    {
        public static async Task<List<Friend>> Execute(DataContext context, int idUser)
        {
             return await context
                    .Friends
                    .AsNoTracking()
                    .Where(f => f.UserId == idUser)
                    .ToListAsync();
        }
    }
}
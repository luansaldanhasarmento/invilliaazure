using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyGames.Data;
using MyGames.Models;

namespace MyGames.Controllers
{
    [Route("v1")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("welcome")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Get([FromServices]DataContext context)
        {
            var user = new User {Username = "invillia", Password = "invillia", Profile = "admin"};
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return Ok(new {message = "Dados configurados, inicie a aplicação com o Usuário 'invillia', senha 'invillia'"});
        }
        
    }
}
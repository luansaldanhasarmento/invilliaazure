using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyGames.Data;
using MyGames.Models;
using MyGames.Services;

namespace MyGames.Controllers
{   
    [Route("v1/users")]
    public class UserController : ControllerBase
    {   

        [HttpGet]
        [Authorize(Roles="admin")]
        public async Task<ActionResult<List<User>>> Get([FromServices]DataContext context)
        {   
            try
            {
                List<User> users = await context.Users.AsNoTracking().ToListAsync();
                return users;
            }
            catch(Exception)
            {
                return BadRequest(new {message = "Erro ao obter usuários, tente novamente"});
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Post([FromBody]User user, [FromServices]DataContext context)
        {   
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {   
                //Força a criação como admin, visto que não temos controles de permissões específicas
                user.Profile = "admin";
                context.Users.Add(user);
                await context.SaveChangesAsync();
                user.Password = "";
                return Ok(user);
            }
            catch(Exception)
            {
                return BadRequest(new {message = "Não foi possível criar usuário"});
            }  
        }

        [HttpPut]
        [Authorize(Roles="admin")]
        public async Task<ActionResult<User>> Put([FromBody]User user, [FromServices]DataContext context, int id)
        {   
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(id != user.Id)
                return NotFound(new {message = "Usuário não encontrado"});

            try
            {   
                context.Entry(user).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(user);
            }
            catch(Exception)
            {
                return BadRequest(new {message = "Não foi possível criar usuário"});
            }  
        }



        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Autheticate([FromBody]User user, [FromServices]DataContext context)
        {   
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
          
            var userDb = await context.Users
            .AsNoTracking()
            .Where(x => x.Username == user.Username && x.Password == user.Password)
            .FirstOrDefaultAsync();

            if(userDb == null)
                return NotFound(new {message = "Usuário ou senha inválido"});
            
            var token = TokenService.GenerateToken(userDb);
            userDb.Password = "";
            return new 
            {
                user = userDb,
                token = token
            };
        }
    }
}
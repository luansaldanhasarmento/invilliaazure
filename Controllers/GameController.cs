using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyGames.Data;
using MyGames.Models;
using MyGames.Services;

namespace MyGames.Controllers
{
    [Route("v1/games")]
    public class GameController : ControllerBase
    {
        private readonly IHttpContextAccessor _accessor;

        public GameController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        [HttpGet]
        [Authorize(Roles="admin")]
        public async Task<ActionResult<List<Game>>> Get([FromServices]DataContext context)
        {   
            var identityUser = _accessor.HttpContext.User.Identity.Name;
            try
            {
                List<Game> games = await GetGamesService.Execute(context, int.Parse(identityUser));
                return Ok(games);
            }
            catch(Exception)
            {
                return BadRequest("Erro ao buscar os jogos, tente novamente");
            }
        }
    
        [Route("{id:int}")]
        [HttpGet]
        [Authorize(Roles="admin")]
        public async Task<ActionResult<Game>> GetById(int id, [FromServices]DataContext context)
        {   
            try
            {
                Game game = await GetGameByIdService.Execute(context, id);

                if(game == null)
                    return NotFound(new {message = "Jogo não encontrado"});

                return Ok(game);
            }
            catch(Exception)
            {
                return BadRequest("Erro ao obter jogo, tente novamente");
            }
        }

        [HttpPost]
        [Authorize(Roles="admin")]
        public async Task<ActionResult<Game>> Post([FromBody]Game game, [FromServices]DataContext context)
        {   

            var identityUser = _accessor.HttpContext.User.Identity.Name;

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await InsertGameService.Execute(context, game, int.Parse(identityUser));
                return Ok(game);
            }
            catch(Exception)
            {
                return BadRequest(new {message = "Não foi possível adicionar jogo"});
            }  
        }

        [Route("{id:int}")]
        [HttpPut]
        [Authorize(Roles="admin")]
        public async Task<ActionResult<Game>> Put(int id, [FromBody]Game game, [FromServices]DataContext context)
        {  
             var identityUser = _accessor.HttpContext.User.Identity.Name;

            if(!ModelState.IsValid)
                return BadRequest(ModelState);   

            if(game.Id != id) 
                return NotFound(new {message = "Jogo não encontrado"});

            try
            {
                await UpdateGameService.Execute(context, game, int.Parse(identityUser));
                context.Entry<Game>(game).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return game;
            }
            catch(DbUpdateConcurrencyException)
            {
                return BadRequest(new {message = "As informações desse jogo já foram atualizadas"});
            }
            catch(Exception)
            {
                return BadRequest(new {message = "Não foi possível atualizar as informações do jogo, tente novamente"});
            }        
        }

        [Route("{id:int}")]
        [HttpDelete]
        [Authorize(Roles="admin")]
        public async Task<ActionResult<Game>> Delete(int id, [FromServices]DataContext context)
        {
            Game game = await GetGameByIdService.Execute(context, id);
            
            if(game == null)
                return NotFound(new {message = "Jogo não encontrado"});

            try{
                await DeleteGameService.Execute(context, game);
                return Ok(new {message = "Jogo removido com sucesso"});
            }
            catch(Exception)
            {
                return BadRequest(new {message = "Não foi possível remover o Jogo"});
            }
        }
    }
}
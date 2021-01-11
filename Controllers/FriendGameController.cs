using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGames.Data;
using MyGames.Exceptions;
using MyGames.Models;
using MyGames.Services;

namespace MyGames.Controllers
{
    [Route("v1/manager")]
    public class FriendGameController : ControllerBase
    {   

        private readonly IHttpContextAccessor _accessor;

        public FriendGameController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        [Route("{id:int}")]
        [HttpGet]
        [Authorize(Roles="admin")]
        public async Task<ActionResult<FriendGame>> GetById(int id, [FromServices]DataContext context)
        {       
           
            try
            {   
                FriendGame friendGame = await GetFriendGameByIdService.Execute(context, id);
                if(friendGame == null)
                    return NotFound(new {message = "Empréstimo não encontrado"});

                return Ok(friendGame);
            }
            catch(Exception)
            {
                return BadRequest("Erro ao obter empréstimo, tente novamente");
            }
        }

        [HttpGet]
        [Authorize(Roles="admin")]
        public async Task<ActionResult<List<FriendGame>>> Get([FromServices]DataContext context)
        {   
            var identityUser = _accessor.HttpContext.User.Identity.Name;
            try
            {  
                List<FriendGame> friendGamesList = await GetFriendGamesService.Execute(context, int.Parse(identityUser));
                return Ok(friendGamesList);
            }
            catch(Exception)
            {
                return BadRequest("Não foi possíver verificar o status dos jogos");
            }
        }

        [HttpPost]
        [Authorize(Roles="admin")]
        [Route("take-game")]
        public async Task<ActionResult<FriendGame>> TakeGame([FromBody]FriendGame friendGame, [FromServices]DataContext context)
        {   

            var identityUser = _accessor.HttpContext.User.Identity.Name;
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await TakeFriendGameService.Execute(context, friendGame, int.Parse(identityUser));
                return Ok(friendGame);
            }
            catch(GameNotAvailableException)
            {
                return BadRequest(new {message = "Esse Jogo já está alugado, para mais informações como quem ou quando foi alugado, você pode consultar pela lista dos seus empréstimos, ;)"});
            } 
            catch(Exception)
            {
                return BadRequest(new {message = "Não foi possível registrar o empréstimo do jogo"});
            }  
        }

        [Route("receive-game/{id:int}")]
        [HttpPut]
        [Authorize(Roles="admin")]
        public async Task<ActionResult<FriendGame>> ReceiveGame(int id, [FromServices]DataContext context)
        { 
            FriendGame friendGameDb = await GetFriendGameByIdService.Execute(context, id);      

            if(!ModelState.IsValid)
                return BadRequest(ModelState);   

            if(friendGameDb.Id != id) 
                return NotFound(new {message = "Empréstimo de jogo não encontrado"});

            try
            {   
                await ReceiveFriendGameService.Execute(context, friendGameDb);
                return friendGameDb;
            }
            catch(Exception)
            {
                return BadRequest(new {message = "Não foi possível atualizar as informações do empréstimo do jogo, tente novamente"});
            }        
        }

        [Route("{id:int}")]
        [HttpDelete]
        [Authorize(Roles="admin")]
        public async Task<ActionResult<FriendGame>> Delete(int id, [FromServices]DataContext context)
        {
            FriendGame friendGame = await GetFriendGameByIdService.Execute(context, id);
            
            if(friendGame == null)
                return NotFound(new {message = "Empréstimo de jogo não encontrado"});

            try{
                await DeleteFriendGameService.Execute(context, friendGame);
                return Ok(new {message = "Empréstimo removido com sucesso"});
            }
            catch(Exception)
            {
                return BadRequest(new {message = "Não foi possível remover o Empréstimo"});
            }
        }

    }
}
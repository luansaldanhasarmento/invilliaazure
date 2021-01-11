using System;
using System.Collections.Generic;
using System.Linq;
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
    [Route("v1/friends")]
    public class FriendController : ControllerBase
    {   
        private readonly IHttpContextAccessor _accessor;

        public FriendController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }


        [HttpGet]
        [Authorize(Roles="admin")]
        public async Task<ActionResult<List<Friend>>> Get([FromServices]DataContext context)
        {   
            var identityUser = _accessor.HttpContext.User.Identity.Name;

            try
            {
                List<Friend> friends = await GetFriendsService.Execute(context, int.Parse(identityUser));
                return Ok(friends);
            }
            catch(Exception)
            {
                return BadRequest("Erro ao buscar amigos, tente novamente");
            }
        }

        [Route("{id:int}")]
        [HttpGet]
        [Authorize(Roles="admin")]
        public async Task<ActionResult<Friend>> GetById(int id, [FromServices]DataContext context)
        {
            try
            {
                Friend friend = await GetFriendByIdService.Execute(context, id);
                if(friend == null)
                    return NotFound(new {message = "Amigo não encontrado"});

                return Ok(friend);
            }
            catch(Exception)
            {
                return BadRequest("Erro ao obter amigo, tente novamente");
            }
        }

        [HttpPost]
        [Authorize(Roles="admin")]
        public async Task<ActionResult<Friend>> Post([FromBody]Friend friend, [FromServices]DataContext context)
        {   

            var identityUser = _accessor.HttpContext.User.Identity.Name;

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await InsertFriendService.Execute(context, friend, int.Parse(identityUser));
                return Ok(friend);
            }
            catch(Exception)
            {
                return BadRequest(new {message = "Não foi possível adicionar amigo"});
            }  
        }

        [Route("{id:int}")]
        [HttpPut]
        [Authorize(Roles="admin")]
        public async Task<ActionResult<Friend>> Put(int id, [FromBody]Friend friend, [FromServices]DataContext context)
        {   

            var identityUser = _accessor.HttpContext.User.Identity.Name;

            if(!ModelState.IsValid)
                return BadRequest(ModelState);   

            if(friend.Id != id) 
                return NotFound(new {message = "Amigo não encontrado"});

            try
            {
                await UpdateFriend.Execute(context, friend, int.Parse(identityUser));
                return friend;
            }
            catch(DbUpdateConcurrencyException)
            {
                return BadRequest(new {message = "As informações desse amigo já foram atualizadas"});
            }
            catch(Exception)
            {
                return BadRequest(new {message = "Não foi possível atualizar as informações do amigo, tente novamente"});
            }        
        }
        
        [Route("{id:int}")]
        [HttpDelete]
        [Authorize(Roles="admin")]
        public async Task<ActionResult<Friend>> Delete(int id, [FromServices]DataContext context)
        {
            Friend friend = await GetFriendByIdService.Execute(context, id);
            
            if(friend == null)
                return NotFound(new {message = "Amigo não encontrado"});

            try
            {
                await DeleteFriendService.Execute(context, friend);
                return Ok(new {message = "Amigo removido com sucesso"});
            }
            catch(Exception)
            {
                return BadRequest(new {message = "Não foi possível remover o amigo"});
            }
        }
    }
}
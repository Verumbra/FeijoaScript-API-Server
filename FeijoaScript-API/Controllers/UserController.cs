using FeijoaAPI_Server.Models;
using FeijoaAPI_Server.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace FeijoaAPI_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var id = await _userRepository.Create(user);
            return new JsonResult(id.ToString());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _userRepository.Get(ObjectId.Parse(id));
            return new JsonResult(user);
        }
        
        [HttpGet("getbyname/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var user = await _userRepository.GetByName(name);
            return new JsonResult(user);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, User user)
        {
            var results = await _userRepository.Update(ObjectId.Parse(id), user);
            return new JsonResult(results);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var results = await _userRepository.DeleteUser(ObjectId.Parse(id));
            return new JsonResult(results);
        }
    }
}

using FeijoaAPI_Server.Models;
using FeijoaAPI_Server.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace FeijoaAPI_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        [HttpPost("create/{userId}")]
        public async Task<IActionResult> Create(ObjectId userId,[FromBody] Recipe recipe)
        {
            var results = await _recipeRepository.CreateRecipe(userId, recipe);
            return new JsonResult(results);
        }
        
        //Get Section

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetRecipe(string id)
        {
            var recipe = await _recipeRepository.GetRecipe(ObjectId.Parse(id));
            return new JsonResult(recipe);
        }

        [HttpGet("getuar/{userID}")]
        public async Task<IActionResult> GetUserAllRecipe(string userID)
        {
            var recipes = await _recipeRepository.GetUserAllRecipe(ObjectId.Parse(userID));
            return new JsonResult(recipes);
        }

        [HttpGet("getowner/{recipeId}")]
        public async Task<IActionResult> GetOwner(string recipeId)
        {
            var owner = await _recipeRepository.GetOwner(ObjectId.Parse(recipeId));
            return new JsonResult(owner);
        }
        
        //Put Section

        [HttpPut("update/{recipeId}")]
        public async Task<IActionResult> UpdateRecip(string recipeId, [FromBody] Recipe recipe)
        {
            var updated = await _recipeRepository.UpdateRecipe(ObjectId.Parse(recipeId), recipe);
            return new JsonResult(updated);
        }
        
    }
}

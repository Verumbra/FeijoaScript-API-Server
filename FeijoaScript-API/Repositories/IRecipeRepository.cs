using FeijoaAPI_Server.Models;
using MongoDB.Bson;

namespace FeijoaAPI_Server.Repositories;


public interface IRecipeRepository
{
    //CREATION
    Task<bool> CreateRecipe(ObjectId userId, Recipe newRecipe);
    
    //READ
    Task<Recipe> GetRecipe(ObjectId recipeId);
    Task<IEnumerable<Recipe>> GetUserAllRecipe(ObjectId userId);
    Task<User> GetOwner(ObjectId recipeId);
    Task<IEnumerable<RecipeIngredient>> GetIngredientList(ObjectId recipeId);
    Task<IEnumerable<Instructions>> GetInstructionList(ObjectId recipeId);
    Task<string> GetRecipeName(ObjectId recipeId);
    Task<IEnumerable<RecipeType>> GetTypes(ObjectId recipeId);
    Task<RecipeArchetype> GetArchetype(ObjectId recipeId);
    
    //UPDATE
    Task<bool> UpdateRecipe(ObjectId recipeId, Recipe newRecipe);
    Task<bool> UpdateName(ObjectId recipeId, string newName);
    Task<bool> UpdateVisiblity(ObjectId recipeId, bool newValue);
    Task<bool> UpdateDescription(ObjectId recipeId, string newDescript);
    Task<bool> UpdateDescriptionTag(ObjectId recipeId, string[] newTagList);
    Task<bool> AddDescriptionTag(ObjectId recipeId, string newTag);
    Task<bool> AddMultiDescriptionTag(ObjectId recipeId, string[] newTags);
    Task<bool> UpdateInstructions(ObjectId recipeId, Instructions newInstruct);
    Task<bool> AddInstructionStep(ObjectId recipeId, string newSteps);
    Task<bool> InsertInstructionStep(ObjectId recipeId, int index, string newSteps);
    Task<bool> UpdateTimeComp(ObjectId recipeId, int time);
    Task<bool> UpdateType(ObjectId recipeId, ObjectId[] typeIds);
    Task<bool> AddType(ObjectId recipeId, ObjectId typeId);
    Task<bool> UpdateArchetype(ObjectId recipeId, ObjectId ArchId);
    
    //DELETE
    Task<bool> DeleteRecipe(ObjectId userId, ObjectId recipeId);
    Task<bool> DeleteStep(ObjectId recipeId, int index);
    Task<bool> DeleteTag(ObjectId recipeId, string tag);
    Task<bool> DeleteType(ObjectId recipeId, ObjectId typeId);
}
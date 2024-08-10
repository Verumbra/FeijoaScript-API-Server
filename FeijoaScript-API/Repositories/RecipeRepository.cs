using FeijoaAPI_Server.Models;
using FeijoaAPI_Server.Models.AggregateModels;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FeijoaAPI_Server.Repositories;

public class RecipeRepository : IRecipeRepository
{
    //This is to map out the recipe collection from the mongodb database
    private readonly IMongoCollection<Recipe> _recipes;
    private readonly IMongoCollection<User> _users;

    //constructor
    public RecipeRepository(IMongoClient client)
    {
        var database = client.GetDatabase("UserRecipeData"); //Store the connection to the db
        var rcollection = database.GetCollection<Recipe>(nameof(Recipe)); //Get and store the collection
        var ucollection = database.GetCollection<User>(nameof(User));
        
        
        _recipes = rcollection; //assign it to a var that's accessible to the rest of the class
        _users = ucollection; //
    }
    
    
    //CREATE
    public async Task<bool> CreateRecipe(ObjectId userId, Recipe newRecipe)
    {
        
        
        await _recipes.InsertOneAsync(newRecipe);
        
        var filter = Builders<User>.Filter.Eq(x=>x._id, userId);
        var update = Builders<User>.Update.Push(x=>x.RecipeCollectionList, newRecipe._id);

        var result = await _users.UpdateOneAsync(filter, update);
        
        return result.ModifiedCount == 1;
    }

    public async Task<Recipe> GetRecipe(ObjectId recipeId)
    {
        var filter = Builders<Recipe>.Filter.Eq(x => x._id, recipeId);
        var recipe = await _recipes.Find(filter).FirstOrDefaultAsync();

        return recipe;
    }

    public async Task<IEnumerable<Recipe>> GetUserAllRecipe(ObjectId userId)
    {
        var pipeline = new EmptyPipelineDefinition<User>()
            .Match(u => u._id == userId)
            .Lookup<User, User, Recipe, AggUserARecipes>(
                _recipes,
                u => u.RecipeCollectionList,
                r => r._id,
                rw => rw.UserRecipes

            ).Unwind(rw => rw.UserRecipes, new AggregateUnwindOptions<Recipe[]>());
        

        return await _users.Aggregate<Recipe[]>(pipeline).FirstOrDefaultAsync();
    }

    public async Task<User> GetOwner(ObjectId recipeId)
    {
        var pipeline = new EmptyPipelineDefinition<Recipe>()
            .Match(r => r._id == recipeId)
            .Lookup<Recipe, Recipe, User, AggRecipeOwner>(
                _users,
                r => r.OwnBy,
                u => u._id,
                ro => ro.recipeOwner
            ).Unwind(ro => ro.recipeOwner, new AggregateUnwindOptions<User>());
        
        return await _recipes.Aggregate<User>(pipeline).SingleOrDefaultAsync();
    }

    public Task<IEnumerable<RecipeIngredient>> GetIngredientList(ObjectId recipeId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Instructions>> GetInstructionList(ObjectId recipeId)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetRecipeName(ObjectId recipeId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<RecipeType>> GetTypes(ObjectId recipeId)
    {
        throw new NotImplementedException();
    }

    public Task<RecipeArchetype> GetArchetype(ObjectId recipeId)
    {
        throw new NotImplementedException();
    }

    
    //UPDATE
    public async Task<bool> UpdateRecipe(ObjectId recipeId, Recipe newRecipe)
    {
        var filter = Builders<Recipe>.Filter.Eq(x => x._id, recipeId);
        var update = Builders<Recipe>.Update
            .Set(x => x.Description, newRecipe.Description)
            .Set(x => x.DescriptionTag, newRecipe.DescriptionTag)
            .Set(x => x.Name, newRecipe.Name)
            .Set(x => x.Instructions, newRecipe.Instructions)
            .Set(x => x.Favorited, newRecipe.Favorited)
            .Set(x => x.IsVisible, newRecipe.IsVisible)
            .Set(x => x.RecipeIng, newRecipe.RecipeIng)
            .Set(x => x.IsType, newRecipe.IsType)
            .Set(x => x.RecipeArch, newRecipe.RecipeArch);
        var result = await _recipes.UpdateOneAsync(filter, update);

        return result.ModifiedCount == 1;

    }

    public Task<bool> UpdateName(ObjectId recipeId, string newName)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateVisiblity(ObjectId recipeId, bool newValue)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateDescription(ObjectId recipeId, string newDescript)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateDescriptionTag(ObjectId recipeId, string[] newTagList)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddDescriptionTag(ObjectId recipeId, string newTag)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddMultiDescriptionTag(ObjectId recipeId, string[] newTags)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateInstructions(ObjectId recipeId, Instructions newInstruct)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddInstructionStep(ObjectId recipeId, string newSteps)
    {
        throw new NotImplementedException();
    }

    public Task<bool> InsertInstructionStep(ObjectId recipeId, int index, string newSteps)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateTimeComp(ObjectId recipeId, int time)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateType(ObjectId recipeId, ObjectId[] typeIds)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddType(ObjectId recipeId, ObjectId typeId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateArchetype(ObjectId recipeId, ObjectId ArchId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteRecipe(ObjectId userId, ObjectId recipeId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteStep(ObjectId recipeId, int index)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteTag(ObjectId recipeId, string tag)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteType(ObjectId recipeId, ObjectId typeId)
    {
        throw new NotImplementedException();
    }
}
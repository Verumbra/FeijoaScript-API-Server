using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FeijoaAPI_Server.Models.AggregateModels;

public class AggRecipeOwner
{
    [BsonElement("Id")]
    public ObjectId Id { get; set; }
    
    [BsonElement("RecipeOwner")]
    public User recipeOwner { get; set; }
}
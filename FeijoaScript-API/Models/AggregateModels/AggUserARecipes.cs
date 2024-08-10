using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FeijoaAPI_Server.Models.AggregateModels;

public class AggUserARecipes
{
    [BsonElement("Id")]
    public ObjectId Id { get; set; }
    
    [BsonElement("UserRecipes")]
    public Recipe[] UserRecipes { get; set; }
}
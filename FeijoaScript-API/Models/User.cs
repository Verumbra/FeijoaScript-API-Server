using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FeijoaAPI_Server.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId _id { get; set; }
    
    [BsonElement("userName")]
    public string UserName { get; set; }
    
    [BsonElement("password")]
    public string Password { get; set; }
    
    [BsonElement("profile")]
    public string Profile { get; set; }
    
    [BsonElement("isFollowing")]
    public ObjectId[] IsFollowing { get; set; }
    
    [BsonElement("bookmarks")]
    public ObjectId[] Bookmarks { get; set; }
        
    [BsonElement("privateLibrary")]
    public ObjectId[] PrivateLibrary { get; set; }
        
    [BsonElement("settings")]
    public String Settings { get; set; }
        
    [BsonElement("recipeCollectionList")]
    public ObjectId[] RecipeCollectionList { get; set; }
}
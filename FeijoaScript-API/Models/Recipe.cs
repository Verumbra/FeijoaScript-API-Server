using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FeijoaAPI_Server.Models;

public class Instructions
{
    [BsonElement("step")]
    public string[] Steps { get; set; }
    
    [BsonElement("CompTime")]
    public int CompTime { get; set; }
}

public class RecipeIngredient
{
    [BsonElement("name")]
    public string Name { get; set; }
    
    [BsonElement("ingredientID")]
    public ObjectId IngredientID { get; set; }
    
    [BsonElement("amount")]
    public string Amount { get; set; }
}

public class Recipe
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId _id { get; set; }
    
    [BsonElement("ownedBy")]
    public ObjectId OwnBy { get; set; }
    
    [BsonElement("rating")]
    public int Rating { get; set; }
    
    [BsonElement("description")]
    public string Description { get; set; }
    
    [BsonElement("descriptionTag")]
    public string[] DescriptionTag { get; set; }
    
    [BsonElement("instructions")]
    public Instructions Instructions { get; set; }
    
    [BsonElement("ingredientsList")]
    public RecipeIngredient[] RecipeIng { get; set; }
    
    [BsonElement("name")]
    public string Name { get; set; }
    
    [BsonElement("isVisible")]
    public bool IsVisible { get; set; }
    
    [BsonElement("isType")]
    public ObjectId[] IsType { get; set; }
    
    [BsonElement("favoritedBy")]
    public ObjectId[] Favorited { get; set; }
    
    [BsonElement("recipeArchetype")]
    public ObjectId RecipeArch { get; set; }
    
}
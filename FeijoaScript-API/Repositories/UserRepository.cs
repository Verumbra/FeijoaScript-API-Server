using FeijoaAPI_Server.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FeijoaAPI_Server.Repositories;

public class UserRepository : IUserRepository
{
    //This is to map out the user collection from the mongodb database
    private readonly IMongoCollection<User> _users;
    
    //constructor
    public UserRepository(IMongoClient client)
    {
        var database = client.GetDatabase("UserRecipeData");
        var collection = database.GetCollection<User>(nameof(User));

        _users = collection;
    }
    
    
    //CREATE
    public async Task<ObjectId> Create(User user)
    {
        await _users.InsertOneAsync(user);
        return user._id;
    }
    
    
    //READ
    public Task<User> Get(ObjectId id)
    {
        var filter = Builders<User>.Filter.Eq(x => x._id, id);
        var user = _users.Find(filter).FirstOrDefaultAsync();
        return user;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        var users = await _users.Find(_ => true).ToListAsync();
        return users;
    }

    public Task<IEnumerable<User>> GetAllAccUsers(ObjectId id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetByName(string name)
    {
        var filter = Builders<User>.Filter.Eq(x => x.UserName, name);
        var users = await _users.Find(filter).ToListAsync();

        return users;
    }

    public Task<User> GetFriend(ObjectId friendId)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetSettings(ObjectId id)
    {
        throw new NotImplementedException();
    }

    
    
    //UPDATE
    public async Task<bool> Update(ObjectId id, User user)
    {
         try
         {
            var filter = Builders<User>.Filter.Eq(x => x._id, id);
            var update =  Builders<User>.Update
                .Set(x => x.UserName, user.UserName)
                .Set(x => x.Password, user.Password)
                .Set(x => x.Profile, user.Profile)
                .Set(x => x.IsFollowing, user.IsFollowing)
                .Set(x => x.Bookmarks, user.Bookmarks)
                .Set(x => x.PrivateLibrary, user.PrivateLibrary)
                .Set(x => x.Settings, user.Settings)
                .Set(x => x.RecipeCollectionList, user.RecipeCollectionList);
            var result = await _users.UpdateOneAsync(filter, update);

            return result.ModifiedCount == 1;
         }
         catch (Exception e) 
         {
            return false; 
         }
        
    }

    public Task<bool> UpdateIsFollowing(ObjectId userId, ObjectId followingId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateLibrary(ObjectId id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateCollectionList(ObjectId id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateSettings(ObjectId id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteUser(ObjectId id)
    {
        var filter = Builders<User>.Filter.Eq(x => x._id, id);
        var result = await _users.DeleteOneAsync(filter);

        return result.DeletedCount == 1;
    }
}
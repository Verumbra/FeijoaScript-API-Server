using FeijoaAPI_Server.Models;
using MongoDB.Bson;

namespace FeijoaAPI_Server.Repositories;

public interface IUserRepository
{
  //creation
  Task<ObjectId> Create(User user);
  
  //read/get
  Task<User> Get(ObjectId id);
  Task<IEnumerable<User>> GetAllUsers();
  Task<IEnumerable<User>> GetAllAccUsers(ObjectId id);
  Task<IEnumerable<User>> GetByName(string name);
  Task<User> GetFriend(ObjectId friendId);
  //todo: get bookmarks
  //todo: get library
  //todo: get collectionList
  Task<string> GetSettings(ObjectId id);
  
  //update
  Task<bool> Update(ObjectId id, User user);
  Task<bool> UpdateIsFollowing(ObjectId userId, ObjectId followingId);
  Task<bool> UpdateLibrary(ObjectId id);
  
  //Task<bool> PushNewLibrary(ObjectId userId, )
  Task<bool> UpdateCollectionList(ObjectId id);
  Task<bool> UpdateSettings(ObjectId id);
  
  //Delete
  Task<bool> DeleteUser(ObjectId id);

}
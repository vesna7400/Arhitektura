using Arhitektura.Roles;
using MongoDB.Driver;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _userCollection;

    public UserRepository()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("arhitektura");
        _userCollection = database.GetCollection<User>("user");
    }

    public void Create(User user)
    {
        _userCollection.InsertOne(user);
    }

    public User GetUser(string username, string password)
    {
        return _userCollection.Find(r => r.Username == username && r.Password == password).FirstOrDefault();
    }

    public bool GetUsername(string username)
    {
        User user = _userCollection.Find(r => r.Username == username).FirstOrDefault();
        if (user != null && user.Username != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}

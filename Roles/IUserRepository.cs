using Arhitektura.Models;
using System.Collections.Generic;

namespace Arhitektura.Roles
{
    public interface IUserRepository
    {
        User GetUser(string username, string password);
        bool GetUsername(string username);
        void Create(User user);
    }
}

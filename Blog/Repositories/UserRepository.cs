using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{

    public class UserRepository
    {
        private readonly SqlConnection _connection;
        
        public UserRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Create(User user)
        {
            _connection.Insert<User>(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _connection.GetAll<User>();
        }

        public User GetById(int id)
        {
            return _connection.Get<User>(id);
        }

        // public void Update(int id)
        // {
        //     _connection.Update<User>(id);
        // }

    }
}
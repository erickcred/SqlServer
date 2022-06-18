using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class RoleRepository
    {
        private readonly SqlConnection _connection;

        public RoleRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Create(Role role)
        {
            _connection.Insert<Role>(role);
        }

        public IEnumerable<Role> GetAll()
        {
            return _connection.GetAll<Role>();
        }

        public Role GetById(int id)
        {
            return _connection.Get<Role>(id);
        }
    }
}
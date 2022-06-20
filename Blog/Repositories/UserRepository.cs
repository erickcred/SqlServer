using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection) : base(connection) 
        {
            _connection = connection;
        }

        public List<User> GetWithRoles()
        {
            var query = @"SELECT
                    [User].*,
                    [Role].*
                FROM
                    [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

            var users = new List<User>();

            var items = _connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var result = users.Where(x => x.Id == user.Id).FirstOrDefault();
                    if (result == null)
                    {
                        result = user;
                        if (role != null)
                        {
                            result.Roles.Add(role);
                        }
                        users.Add(user);
                    } else
                    {
                        result.Roles.Add(role);
                    }
                    return user;
                }, splitOn: "Id"
            );

            return users;
        }
    }
}
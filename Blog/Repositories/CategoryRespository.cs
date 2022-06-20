using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        private readonly SqlConnection _connection;

        public CategoryRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        public List<Category> ReadCategoryAndQuantityPost()
        {
            string query = @"SELECT
                    [Category].[Id],
                    [Category].[Name],
                    [Category].[Slug],
                    COUNT([Post].[Id]) AS [TotalPost]
                FROM
                    [Category]
                    INNER JOIN [Post] ON [Category].[Id] = [Post].[CategoryId]
                GROUP BY
                    [Category].[Id],
                    [Category].[Name],
                    [Category].[Slug]";

            var categories = new List<Category>();

            return (List<Category>)_connection.Query<Category>(query);
        }
    }
}
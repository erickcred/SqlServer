using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Screens
{
    public class GernericalLists
    {
        private readonly SqlConnection _connection;

        public GernericalLists(SqlConnection connection)
        {
            _connection = connection;
        }

        public void ReadUsers()
        {
            var repository = new UserRepository(_connection);

            foreach (var item in repository.GetWithRoles())
            {
                Console.Write($"{item.Name}, {item.Email}, ");
                foreach (var role in item.Roles)
                {
                    Console.Write($"{role.Name}");
                }
                Console.WriteLine();
            }
        }

        public void ReadCategories()
        {
            var repository = new CategoryRepository(_connection);
            foreach (var item in repository.ReadCategoryAndQuantityPost())
            {
                Console.WriteLine($"{item.Name}, Total posts: {item.TotalPost}");
            }
        }
    }
}
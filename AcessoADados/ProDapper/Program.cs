using System;
using Dapper;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using ProDapper.Models;


namespace ProDapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string connectionString = @"Data Source=localhost\SQLEXPRESS;Database=erickcred;TrustServerCertificate=true;User ID=sa;Password=123";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // ProcessConnections.CreateCategory(connection); // Create
                // ProcessConnections.CreateManyCategory(connection); // Create
                // ProcessConnections.ExecuteScalar(connection); // Create
                // ProcessConnections.UpdateCategory(connection);

                // ProcessConnections.ListCategories(connection);
                // ProcessConnections.ListCategories(connection);
                // ProcessConnections.ListStudents(connection);
                // ProcessConnections.LisCoursesByCategory(connection);
                // ProcessConnections.ViewListCourse(connection);

                // ProcessConnections.DeleteCategory(connection);
                // ProcessConnections.ExecuteDeletedStudentProcedure(connection);

                // ProcessConnections.OneToOne(connection);
                ProcessConnections.OneToMany(connection);




            }
        }
    
    }
}
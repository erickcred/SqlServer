using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using ProDapper.Models;

namespace ProDapper
{
    public abstract class ProcessConnections
    {

        // Create
        public static void CreateCategory(SqlConnection connection)
        {
            Category category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "PHP";
            category.Url = "php";
            category.Summary = "Primeiros passos";
            category.Order = 8;
            category.Description = "Iniciando com PHP";
            category.Featured = false;

            string insertSql = @"INSERT INTO [Category] VALUES
            (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

            var rows = connection.Execute(insertSql, new {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });
            Console.WriteLine($"Lines afected {rows}");
        }

        public static void CreateManyCategory(SqlConnection connection)
        {
            Category category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Docker";
            category.Url = "docker";
            category.Summary = "Primeiros passos";
            category.Order = 0;
            category.Description = "Instalando Docker";
            category.Featured = false;

            Category category2 = new Category();
            category2.Id = Guid.NewGuid();
            category2.Title = "Javascript";
            category2.Url = "javascript";
            category2.Summary = "Primeiros passos";
            category2.Order = 0;
            category2.Description = "Iniciando com JS";
            category2.Featured = true;

            string insertSql = @"INSERT INTO [Category] VALUES
            (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

            var rows = connection.Execute(insertSql, new[] {
                new {
                    category.Id,
                    category.Title,
                    category.Url,
                    category.Summary,
                    category.Order,
                    category.Description,
                    category.Featured
                },
                new {
                    category2.Id,
                    category2.Title,
                    category2.Url,
                    category2.Summary,
                    category2.Order,
                    category2.Description,
                    category2.Featured
                }
            });
            Console.WriteLine($"Lines afected {rows}");
        }

        public static void ExecuteScalar(SqlConnection connection)
        {
            Category category = new Category();
            category.Title = "Outro TituloS";
            category.Url = "outro-tituloS";
            category.Summary = "OutroS";
            category.Order = 0;
            category.Description = "Essa descrição OutroS";
            category.Featured = true;

            string createSql = @" INSERT INTO
                    [Category]
                    OUTPUT INSERTED.[Id]
                VALUES(
                    NEWID(),
                    @Title,
                    @Url,
                    @Summary,
                    @Order,
                    @Description,
                    @Featured
                )";

            var id = connection.ExecuteScalar<Guid>(createSql, new 
            {
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });
            Console.WriteLine($"Item Id:{id} add");
        }

        // Updates
        public static void UpdateCategory(SqlConnection connection)
        {
            string updateSql = @"UPDATE [Category] SET
            [Title]=@Title, [Url]=@Url, [Summary]=@Summary, [Order]=@Order, [Description]=@Description, [Featured]=@Featured
            WHERE [Id]=@Id";

            Category category = new Category();
            category.Id = new Guid("4aeb11ef-e178-43ff-8b3e-25432cb725d5");
            category.Title = "Docker";
            category.Url = "docker";
            category.Summary = "Primeiros passos";
            category.Order = 8;
            category.Description = "Instalando Docker";
            category.Featured = false;

            int rows = connection.Execute(updateSql, new {
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured,
                category.Id,
            });
            Console.WriteLine($"Lines afected {rows}");
        }

        // Lists
        public static void ListCategories(SqlConnection connection)
        {
            IEnumerable<Category> categories = connection.Query<Category>("SELECT TOP 100 [Id], [Title], [Summary], [Description] FROM [Category]");
            foreach (Category category in categories)
            {
                Console.WriteLine($"{category.Id} - {category.Title} - {category.Summary} - {category.Description}");
            }
        }

        public static void ListStudents(SqlConnection connection)
        {
            IEnumerable<Student> students = connection.Query<Student>("SELECT TOP 100 * FROM [Student]");
            if (students.Count() > 0)
            {
                foreach (Student student in students)
                {
                    Console.WriteLine($"{student.Id} - {student.Name} - {student.Birthdate}");
                }
            } else 
            {
                Console.WriteLine("Não há dados de Studantes para listar");
            }
        }

        public static void LisCoursesByCategory(SqlConnection connection)
        {
            string cousersByCategorySql = "[spGetCoursesByCategory]";

            var paramiter = new { CategoryId = "af3407aa-11ae-4621-a2ef-2028b85507c4" };
            var courses = connection.Query<Course>(
                cousersByCategorySql,
                paramiter,
                commandType: System.Data.CommandType.StoredProcedure);

            foreach (Course course in courses)
            {
                Console.WriteLine($"{course.Id} - {course.Tag} - {course.Title} - {course.Active} - {course.Free} - {course.Featured}");
            }

        }

        public static void ViewListCourse(SqlConnection connection)
        {
            string sqlViewListCourse = "SELECT * FROM [vwCourse]";

            IEnumerable<Course> listView = connection.Query<Course>(sqlViewListCourse);
            foreach (Course course in listView)
            {
                Console.WriteLine($"{course.Id} - {course.Title}");
            }
        }

        // Delet
        public static void DeleteCategory(SqlConnection connection)
        {
            string deleteSql = @"DELETE FROM [Category] WHERE [Id]=@Id";

            int rows = connection.Execute(deleteSql, new {
                Id = new Guid("4aeb11ef-e178-43ff-8b3e-25432cb725d5")
            });
            Console.WriteLine($"Lines afected {rows}");
        }
    
        
        // Deletando por PROCEDURE spDeleteStudent
        public static void ExecuteDeletedStudentProcedure(SqlConnection connection)
        {
            string deleteProcSql = "EXEC [spDeleteStudent] @StudentId";

            var paramiter = new { StudentId = "4968d91b-4e06-42d6-806a-f00c490a4c7f" };

            var rows = connection.Execute(
                deleteProcSql,
                paramiter
                // commandType: System.Data.CommandType.StoredProcedure
            );
            Console.WriteLine($"Lines afecteds {rows}");
        }

        // List ById
        public static void OneToOne(SqlConnection connection)
        {
            string listByIdSql = @"SELECT TOP 5
                    *
                FROM
                    [CareerItem]
                    INNER JOIN [Course] ON [CareerItem].[CourseId] = [Course].[Id]";

            var items = connection.Query<CareerItem, Course, CareerItem>(
                listByIdSql,
                (careerItem, course) => {
                    careerItem.Course = course;
                    return careerItem;
                }, splitOn: "Id"
            );

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Title} \nCurso: {item.Course.Title} Lançamento: {item.Course.CreateDate.ToString("dd/MM/yyyy")}\n");
            }
        }

        public static void OneToMany(SqlConnection connection)
        {
            string sql =@"
                SELECT
                    [Career].[Id],
                    [Career].[Title],
                    [CareerItem].[CareerId],
                    [CareerItem].[Title]
                FROM
                    [Career]
                    INNER JOIN 
                        [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
                ORDER BY 
                    [Career].[Title]";
 
            var careers = new List<Career>();
            var items = connection.Query<Career, CareerItem, Career>(
                sql,
                (career, careerItem) => 
                {
                    var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
                    if (car == null)
                    {
                        car = career;
                        car.CareerItems.Add(careerItem);
                        careers.Add(car);
                    } else
                    {
                        car.CareerItems.Add(careerItem);
                    }
                    return career;
                }, splitOn: "CareerId"
            );

            foreach (var career in careers)
            {
                Console.WriteLine($"{career.Title}");
                foreach (var item in career.CareerItems)
                {
                    Console.WriteLine($" - {item.Title}");
                }
            }
        }
    }
}
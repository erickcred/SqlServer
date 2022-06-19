using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Role]")]
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public override string ToString()
        {
            string role = "Role";
            return $"{role} \n{Id} - {Name} - {Slug}";
        }
    }
}
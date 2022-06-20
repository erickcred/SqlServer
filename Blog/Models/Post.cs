using System.Text;
using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Post]")]
    public class Post
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

       
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Id);
            sb.Append($" - {CategoryId}");
            sb.Append($" - {AuthorId}");
            sb.AppendLine();
            sb.Append($" - {Title}");
            sb.Append($" - {Summary}");
            sb.AppendLine();
            sb.Append(Body);
            sb.AppendLine();
            sb.Append(Slug);
            sb.AppendLine();
            sb.Append(CreateDate);
            sb.Append($" - {LastUpdateDate}");

            return sb.ToString();
        }
        
    }
}
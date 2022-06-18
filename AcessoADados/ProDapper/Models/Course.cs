namespace ProDapper.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Tag { get; set; }
        public string Title { get; set ;}
        public string Summary { get; set; }
        public string Url { get; set; }
        public int Level { get; set; }
        public int DurationMinutes { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public bool Active { get; set; }
        public bool Free { get; set; }
        public bool Featured { get; set; }
        // public Author AuthorId { get; set; }
        // public Category CategoryId { get; set; }
        public string Tags { get; set; }
        
    }
}
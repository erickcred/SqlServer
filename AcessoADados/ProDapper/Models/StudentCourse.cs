namespace ProDapper.Models
{
    public class StudentCourse
    {
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        public int Process { get; set; }
        public bool Favorite { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

    }
}
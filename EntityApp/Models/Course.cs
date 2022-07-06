namespace EntityApp.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DurationDays { get; set; }

        public List<Student> Students { get; set; }

    }
}

namespace EntityApp.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FullName {get;set ;}
        public string Email {get;set; }
        public List<Course> Courses { get; set; }
    }
}

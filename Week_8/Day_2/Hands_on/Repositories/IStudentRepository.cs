using WebApplication8.Models;

namespace WebApplication8.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudentsWithCourse();
        IEnumerable<Course> GetCoursesWithStudents();
    }
}

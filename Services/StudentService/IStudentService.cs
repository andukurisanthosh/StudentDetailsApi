using StudentDetailsApi.Models;

namespace StudentDetailsApi.Services.StudentService
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudent(int id);
        Task<List<Student>> AddStudent(Student student);
        Task<List<Student>?> UpdateStudent(int id, Student student);
        Task<List<Student>?> DeleteStudent(int id);

    }
}

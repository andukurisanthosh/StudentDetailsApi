using StudentDetailsApi.Data;
using StudentDetailsApi.Models;

namespace StudentDetailsApi.Services.StudentService
{
    public class StudentService : IStudentService
    {
        

        private readonly DataContext _context;

        public StudentService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return await _context.Students.ToListAsync();
        }

        public async Task<List<Student>?> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return null;
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return await _context.Students.ToListAsync();
        }

        public async Task<List<Student>> GetAllStudents()
        {
            var student = await _context.Students.ToListAsync();
            return student;
        }

        public async Task<Student> GetStudent(int id)
        {
            var student =await _context.Students.FindAsync(id);
            if (student == null)
            {
                return null;
            }
            return student;
        }

        public async Task<List<Student>?> UpdateStudent(int id, Student request)
        {
            var student =await _context.Students.FindAsync(id);
            if (student == null)
            {
                return null;
            }

            student.Id = request.Id;
            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.Place = request.Place;

            await _context.SaveChangesAsync();

            return await _context.Students.ToListAsync();
        }
    }
}

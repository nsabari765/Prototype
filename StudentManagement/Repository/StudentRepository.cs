using StudentManagement.Models;

namespace StudentManagement.Repository
{
    public interface IStudentRepository
    {
        Task<Student> GetById(int id);
    }
    public class StudentRepository : IStudentRepository
    {
        public Task<Student> GetById(int id)
        {
            return null;
        }
    }
}

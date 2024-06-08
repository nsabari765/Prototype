using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Models;

namespace StudentManagement.Repository
{
    public interface IStudentRepository
    {
        Task<Student> SaveOrUpdate(Student student);

        Task<List<Student>> GetAllStudents();

        Task<Student> GetStduentById(int id);

        Student Delete(Student student);
    }

    public class StudentRepository : IStudentRepository
    {
        public readonly DataContext context;

        public StudentRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<Student> SaveOrUpdate(Student student)
        {
            var studentInDb = await context.Student.FindAsync(student.Id);

            if (student.File != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                                @"wwwroot\uploading", student.File.FileName);

                using var stream = new FileStream(filePath, FileMode.Create);

                student.File.CopyTo(stream);

                student.Stu_Image = student.File.FileName;
            }

            if (studentInDb == null)
            {
                await context.Student.AddAsync(student);
            }
            else
            {
                studentInDb.Name = student.Name;
                studentInDb.RollNumber = student.RollNumber;
                studentInDb.DOB = student.DOB;
                studentInDb.Phone = student.Phone;
                studentInDb.Email = student.Email;
                studentInDb.Gender = student.Gender;
                studentInDb.Address = student.Address;
                studentInDb.Department = student.Department;
                studentInDb.Stu_Image = student.File.FileName;
            }

            await context.SaveChangesAsync();
            return student;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            var students = await context.Student.ToListAsync();
            return students;
        }

        public async Task<Student> GetStduentById(int id)
        {
            var students = await context.Student.FindAsync(id);

            return students;
        }

        public Student Delete(Student stduent)
        {
            var studentInDb = context.Student.Find(stduent.Id);

            if (studentInDb != null)
            {
                context.Student.Remove(studentInDb);
            }
            context.SaveChanges();

            return studentInDb;
        }
    }
}
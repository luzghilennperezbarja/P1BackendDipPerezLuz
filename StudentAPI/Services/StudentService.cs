using System.Collections.Generic;
using System.Linq;
using StudentAPI.Models;

namespace StudentAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly List<Student> _students = new List<Student>();

        public List<Student> GetAll()
        {
            return _students;
        }

        public Student? GetByCI(int ci)
        {
            return _students.FirstOrDefault(s => s.CI == ci);
        }

        public Student Create(Student student)
        {
            _students.Add(student);
            return student;
        }

        public Student? Update(int ci, Student updatedStudent)
        {
            var existing = _students.FirstOrDefault(s => s.CI == ci);
            if (existing != null)
            {
                existing.Nombre = updatedStudent.Nombre;
                existing.Nota = updatedStudent.Nota;
                return existing;
            }
            return null;
        }

        public Student? Delete(int ci)
        {
            var student = _students.FirstOrDefault(s => s.CI == ci);
            if (student != null)
            {
                _students.Remove(student);
                return student;
            }
            return null;
        }
    }
}
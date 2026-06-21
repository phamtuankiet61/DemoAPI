using DemoAPI.Data;
using DemoAPI.DTOs.Student;
using DemoAPI.Models;
using Microsoft.EntityFrameworkCore;
using DemoAPI.DTOs.Student;

namespace DemoAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        //public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        //{
        //    return await _context.Students
        //        .Include(s => s.ClassRoom) // Nhớ Include để lấy thông tin ClassRoom
        //        .Select(student => new StudentDto
        //        {
        //            Id = student.Id,
        //            FullName = student.FullName,
        //            Age = student.Age,
        //            DateOfBirth = student.DateOfBirth,
        //            Email = student.Email,
        //            Address = student.Address,
        //            GPA = student.GPA,
        //            ClassRoomId = student.ClassRoomId,
        //            ClassRoomName = student.ClassRoom != null ? student.ClassRoom.Name : "Chưa có lớp"
        //        })
        //        .ToListAsync();
        //}

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student != null)
            {
                _context.Students.Remove(student);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<(List<Student> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _context.Students.Include(s => s.ClassRoom).AsNoTracking();

            var totalCount = await query.CountAsync();

            // Phân trang dữ liệu trực tiếp dưới database
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
    }
}

using DemoAPI.Data;
using DemoAPI.DTOs.ClassRoom;
using DemoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Repositories
{
    public class ClassRoomRepository : IClassRoomRepository
    {
        private readonly AppDbContext _context;

        public ClassRoomRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClassRoom>> GetAllAsync()
        {
            //return await _context.ClassRooms.ToListAsync();
            return await _context.ClassRooms.AsQueryable().ToListAsync();
        }

        //public async Task<IEnumerable<ClassRoomListDto>> GetAllClassRoomsAsync()
        //{
        //    return await _context.ClassRooms
        //        .Select(c => new ClassRoomListDto
        //        {
        //            Id = c.Id,
        //            Name = c.Name,
        //            TotalStudents = c.Students.Count // Đếm số lượng học sinh trực tiếp bằng SQL
        //        })
        //        .ToListAsync();
        //}

        public async Task<ClassRoom?> GetByIdAsync(int id)
        {
            return await _context.ClassRooms.FindAsync(id);
        }

        //public async Task<ClassRoomDto?> GetClassRoomByIdAsync(int id)
        //{
        //    return await _context.ClassRooms
        //        .Where(c => c.Id == id)
        //        .Select(c => new ClassRoomDto
        //        {
        //            Id = c.Id,
        //            Name = c.Name,
        //            Students = c.Students.Select(s => new StudentInClassDto
        //            {
        //                Id = s.Id,
        //                FullName = s.FullName,
        //                Email = s.Email,
        //                GPA = s.GPA
        //            }).ToList()
        //        })
        //        .FirstOrDefaultAsync();
        //}

        public async Task AddAsync(ClassRoom classRoom)
        {
            await _context.ClassRooms.AddAsync(classRoom);
        }

        public void Update(ClassRoom classRoom)
        {
            _context.ClassRooms.Update(classRoom);
        }

        public void Delete(ClassRoom classRoom)
        {
            _context.ClassRooms.Remove(classRoom);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

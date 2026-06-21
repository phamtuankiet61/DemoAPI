using DemoAPI.Models;

namespace DemoAPI.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync(); 

        Task<Student?> GetByIdAsync(int id);

        Task AddAsync(Student student);

        Task UpdateAsync(Student student);

        Task DeleteAsync(int id);

        Task SaveChangesAsync();
    }
}

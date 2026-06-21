using DemoAPI.Models;

namespace DemoAPI.Repositories
{
    public interface IClassRoomRepository
    {
        Task<List<ClassRoom>> GetAllAsync();

        Task<ClassRoom?> GetByIdAsync(int id);

        Task AddAsync(ClassRoom classRoom);

        void Update(ClassRoom classRoom);

        void Delete(ClassRoom classRoom);

        Task SaveChangesAsync();
    }

}

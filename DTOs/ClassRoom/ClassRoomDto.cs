namespace DemoAPI.DTOs.ClassRoom
{
    public class ClassRoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Danh sách học sinh thuộc lớp này (đã được tối giản)
        public List<StudentInClassDto> Students { get; set; } = [];
    }

    // Một Helper DTO nhỏ nằm trong cùng file phục vụ riêng cho ClassRoomDto
    public class StudentInClassDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public double GPA { get; set; }
    }
}

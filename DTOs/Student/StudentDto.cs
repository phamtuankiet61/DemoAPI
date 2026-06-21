using DemoAPI.Models;

namespace DemoAPI.DTOs.Student
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public double GPA { get; set; }

        // Thông tin lớp học được làm phẳng
        public int ClassRoomId { get; set; }
        public string ClassRoomName { get; set; } = string.Empty;
    }
}

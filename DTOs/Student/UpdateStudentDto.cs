using System.ComponentModel.DataAnnotations;

namespace DemoAPI.DTOs.Student
{
    public class UpdateStudentDto
    {
        [Required(ErrorMessage = "Họ và tên không được để trống.")]
        public string FullName { get; set; } = string.Empty;

        [Range(1, 100, ErrorMessage = "Tuổi hợp lệ từ 1-100.")]
        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Email không được để trống.")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
        public string Email { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        [Range(0.0, 4.0, ErrorMessage = "GPA từ 0.0 đến 4.0.")]
        public double GPA { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn lớp học.")]
        public int ClassRoomId { get; set; }

    }
}

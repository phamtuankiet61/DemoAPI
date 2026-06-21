using System.ComponentModel.DataAnnotations;

namespace DemoAPI.DTOs.Student
{
    public class CreateStudentDto
    {
        [Required(ErrorMessage = "Họ và tên không được để trống.")]
        [StringLength(100, ErrorMessage = "Họ và tên không được quá 100 ký tự.")]
        public string FullName { get; set; } = string.Empty;

        [Range(1, 100, ErrorMessage = "Tuổi phải nằm trong khoảng từ 1 đến 100.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Ngày sinh không được để trống.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Email không được để trống.")]
        [EmailAddress(ErrorMessage = "Định dạng Email không hợp lệ.")]
        public string Email { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Địa chỉ không được quá 200 ký tự.")]
        public string Address { get; set; } = string.Empty;

        [Range(0.0, 4.0, ErrorMessage = "Điểm GPA phải nằm trong khoảng từ 0.0 đến 4.0.")]
        public double GPA { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn lớp học.")]
        public int ClassRoomId { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace DemoAPI.DTOs.ClassRoom
{
    public class CreateClassRoomDto
    {
        [Required(ErrorMessage = "Tên lớp học không được để trống.")]
        [StringLength(50, ErrorMessage = "Tên lớp học không được quá 50 ký tự.")]
        public string Name { get; set; } = string.Empty;
    }

}

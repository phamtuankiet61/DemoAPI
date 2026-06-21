namespace DemoAPI.DTOs.ClassRoom
{
    public class ClassRoomListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TotalStudents { get; set; } // Trả về số lượng học sinh trong lớp

    }
}

using DemoAPI.DTOs.Student;
using FluentValidation;

namespace DemoAPI.Validators
{
    public class CreateStudentDtoValidator : AbstractValidator<CreateStudentDto>
    {
        public CreateStudentDtoValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Họ và tên không được để trống.")
                .MaximumLength(100).WithMessage("Họ và tên không được quá 100 ký tự.");

            RuleFor(x => x.Age)
                .InclusiveBetween(1, 100).WithMessage("Tuổi phải nằm trong khoảng từ 1 đến 100.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email không được để trống.")
                .EmailAddress().WithMessage("Định dạng Email không hợp lệ.");

            RuleFor(x => x.GPA)
                .InclusiveBetween(0.0, 4.0).WithMessage("Điểm GPA phải từ 0.0 đến 4.0.");

            RuleFor(x => x.ClassRoomId)
                .GreaterThan(0).WithMessage("Vui lòng chọn một lớp học hợp lệ.");
        }

    }
}

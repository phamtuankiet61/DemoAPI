using AutoMapper;
using DemoAPI.DTOs.Student;
using DemoAPI.Models;
using DemoAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentDto>>> GetAll()
        {
            var students = await _repository.GetAllAsync();
            var studentDtos = _mapper.Map<List<StudentDto>>(students);

            return Ok(studentDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetById(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student == null) return NotFound();

            var studentDto = _mapper.Map<StudentDto>(student);

            return Ok(studentDto);
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> Create(CreateStudentDto createStudentDto)
        {
            var studentEntity = _mapper.Map<Student>(createStudentDto);

            await _repository.AddAsync(studentEntity);
            await _repository.SaveChangesAsync();

            var resultDto = _mapper.Map<StudentDto>(studentEntity);

            return CreatedAtAction(nameof(GetById), new { id = studentEntity.Id }, resultDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateStudentDto updateStudentDto)
        {
            var existingStudent = await _repository.GetByIdAsync(id);
            if (existingStudent == null) return NotFound();

            _mapper.Map(updateStudentDto, existingStudent);

            await _repository.UpdateAsync(existingStudent);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingStudent = await _repository.GetByIdAsync(id);
            if (existingStudent == null) return NotFound();

            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

    }
}

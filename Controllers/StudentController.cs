using GenericProject.Model;
using GenericProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace GenericProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IRepository<Student> _StudentRepository;

        public StudentController(IRepository<Student> StudentRepository)
        {
            _StudentRepository = StudentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var students = await _StudentRepository.GetAllAsync();
                return Ok(students);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            try
            {
                var studentEntity = new Student()
                {
                    Name = student.Name,
                    Address = student.Address,
                    City=student.City,
                    PhoneNumber=student.PhoneNumber,
                    Email=student.Email,
                    CreatedAt = DateTime.Now
                };

                var addedStudent=await _StudentRepository.AddAsync(studentEntity);
                return Ok(new
                {
                    addedStudent,
                    message = "Student Added Successfully"

                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> EditStudnet([FromBody] Student student,int id)
        {
            try
            {
                var studentEntity = await _StudentRepository.GetByIdAsync(id);
                if (studentEntity == null)
                {
                    return NotFound();
                }
                studentEntity.Name = student.Name;
                studentEntity.Address = student.Address;
                studentEntity.City = student.City;
                studentEntity.PhoneNumber = student.PhoneNumber;
                studentEntity.Email = student.Email;
                studentEntity.CreatedAt = DateTime.Now;
                return Ok(new
                {
                    message = "Blog Updated Successfully"
                });

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

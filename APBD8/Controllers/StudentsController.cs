using APBD8.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBD8.Controllers;

[ApiController]
[Route("students")]
public class StudentsController : ControllerBase
{
    private List<Student> _students = new List<Student>();

    public StudentsController()
    {
        _students.Add(new Student { FirstName = "John", LastName = "Doe" });
        _students.Add(new Student { FirstName = "Jane", LastName = "Doe" });
        _students.Add(new Student { FirstName = "Julie", LastName = "Doe" });
    }
    
    
    [HttpGet]
    public IActionResult GetStudents(string orderBy)
    {
        if (_students == null)
        {
            return NotFound();
        }
        return Ok(_students);
    }
    
    [HttpGet("{firstName}")]
    public IActionResult GetStudent(string firstName)
    {
        var student = _students.FirstOrDefault(s => s.FirstName == firstName);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }
    

}
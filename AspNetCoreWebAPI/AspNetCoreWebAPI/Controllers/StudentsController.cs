using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebAPI.Controllers.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        List<Student> _oStudents = new List<Student>()
        {
            new Student(){Id= 1, Name="Boy",roll=121 },
            new Student(){Id= 2, Name="Boy2",roll=122 },
            new Student(){Id= 3, Name="Boy3",roll=123 },
            new Student(){Id= 4, Name="Boy4",roll=124 },
            new Student(){Id= 5, Name="Boy5",roll=125 },

        };
        [HttpGet]
        public IActionResult Gets()
        {
            if (_oStudents.Count == 0)
            {
                return NotFound("No list found");
            }
            return Ok(_oStudents);
        }
        [HttpGet("GetStudent")]
        public IActionResult Get(int id)
        {
            var oStudent = _oStudents.SingleOrDefault(x => x.Id == id);
            if (oStudent == null)
            {
                return NotFound("No Student found.");
            }
            return Ok(oStudent);
        }

        [HttpPost]
        public IActionResult Save(Student oStudent)
        {
            _oStudents.Add(oStudent);
            if (_oStudents.Count == 0)
            {
                return NotFound("No list found.");
            }
            return Ok(_oStudents);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var oStudent = _oStudents.SingleOrDefault(x => x.Id == id);
            if (oStudent == null)
            {
                return NotFound("No Student found.");
            }
            _oStudents.Remove(oStudent);

            if (_oStudents.Count == 0)
            {
                return NotFound("No list found.");
            }
            return Ok(_oStudents);
        }
       
        
            
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentContext _context;

        public StudentsController(StudentContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Wyświetl listę studentów
        /// </summary>
        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudent()
        {
            if (_context.Student == null)
            {
                return NotFound();
            }
            return await _context.Student
            .Select(x => StudentDTO(x))
            .ToListAsync();
        }
        /// <summary>
        /// Wyświetl studenta
        /// </summary>
        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> GetStudent(int id)
        {
            if (_context.Student == null)
            {
                return NotFound();
            }
            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return StudentDTO(student);
        }


        //// GET: api/Students
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
        //{
        //  if (_context.Student == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Student.ToListAsync();
        //}

        //// GET: api/Students/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Student>> GetStudent(int id)
        //{
        //  if (_context.Student == null)
        //  {
        //      return NotFound();
        //  }
        //    var student = await _context.Student.FindAsync(id);

        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    return student;
        //}

        /// <summary>
        /// Zmień dane studenta
        /// </summary>
        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Wprowadź studenta
        /// </summary>
        /// <param name="student"></param>
        /// <returns>A newly created Student</returns>
        /// <remarks>
        /// Sample request:
        ///
        /// POST /Student
        /// {
        /// "id": 1,
        /// "name": "Anna",
        /// "surnname": "Zablotni"
        /// }
        ///
        /// </remarks>
        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
          if (_context.Student == null)
          {
              return Problem("Entity set 'StudentContext.Student'  is null.");
          }
            _context.Student.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        /// <summary>
        /// Usuwanie Studentow z listy.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (_context.Student == null)
            {
                return NotFound();
            }
            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return (_context.Student?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        ///StudentDTO

        private static StudentDTO StudentDTO(Student student) =>
 new StudentDTO
 {
     Id = student.Id,
     Name = student.Name,
     Surname = student.Surname,
 };



    }
}

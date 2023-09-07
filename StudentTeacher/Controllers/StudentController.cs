using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentTeacher.Model;

namespace StudentTeacher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
       private readonly Context _context;

        public StudentController(Context context)
        {
            _context = context;
        }

        [HttpPost("PostStudent")]
        public ActionResult PostStudent(Student student)
        {
            _context.Add(student);
            _context.SaveChanges();

            return Ok();
        }
        [HttpGet]
        public ActionResult GetStudent(int id)
        {
            var jobId = BackgroundJob.Enqueue(
    () => Console.WriteLine("Fire-and-forget!"));
            var result = _context.Students.Find(id);
            return Ok(result);
        }
        [HttpPut]
        public ActionResult PutStudent(Student student,int id)
        {
           var guncelle= _context.Students.Find(id);
            if (guncelle != null)
            {
                guncelle.StudentName = student.StudentName;
                guncelle.StudentSurname= student.StudentSurname;
                guncelle.StudentEmail= student.StudentEmail;
                guncelle.StudentNumber= student.StudentNumber;
                _context.SaveChanges();
                return Ok();
            }
            return Ok();
        }
        [HttpDelete("DeleteStudent")]
        public ActionResult DeleteStudent(int id)
        {
           var silinecek= _context.Students.Find(id);
            _context.Remove(silinecek);
            _context.SaveChanges();
            return Ok();
        }
       
    }
}

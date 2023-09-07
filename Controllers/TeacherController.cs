using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentTeacher.Model;

namespace StudentTeacher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly Context _context;

        public TeacherController(Context context)
        {
            _context = context;
        }
        [HttpPost("PostTeacher")]
        public ActionResult PostTeacher(Teacher teacher)
        {
            _context.Add(teacher);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("GetTeacher")]
        public ActionResult GetTeacher(int id)
        {
            var teach = _context.Teachers.Find(id);
            return Ok(teach);
        }

        [HttpDelete("DeleteTeacher")]
        public ActionResult DeleteTeacher(int id)
        {
            var silinecek = _context.Teachers.Find(id);
            _context.Remove(silinecek);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("PutTeacher")]
        public ActionResult PutTeacher(int id,Teacher teacher)
        {
            var guncelle = _context.Teachers.Find(id);
            if(guncelle != null)
            {
                guncelle.TeacherName = teacher.TeacherName;
                guncelle.TeacherSurname = teacher.TeacherSurname;
                guncelle.TeacherEmail= teacher.TeacherEmail;    
                guncelle.TeacherBranch=teacher.TeacherBranch;
                _context.SaveChanges();
                return Ok();
            }
            return Ok();

        }
    }
}

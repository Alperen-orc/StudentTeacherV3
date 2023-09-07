using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.DTO
{
    public class TeacherStudentByIdDTO
    {
        public int TeacherStudentID { get; set; }
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
    }
}

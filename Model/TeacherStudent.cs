namespace StudentTeacher.Model
{
    public class TeacherStudent
    {
        public int TeacherStudentID { get; set; }
        public int TeacherID { get; set; }
        public virtual Teacher Teacher { get; set;}
        public int StudentID { get; set; }
        public virtual Student Student { get; set;}


    }
}

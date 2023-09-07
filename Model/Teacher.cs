namespace StudentTeacher.Model
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string TeacherName { get; set; } = string.Empty;
        public string TeacherSurname { get; set; } = string.Empty;
        public string TeacherEmail { get; set; } = string.Empty;
        public string TeacherBranch { get; set; }=string.Empty;
        //public ICollection<Student> Students { get; set; }
        
    }
}

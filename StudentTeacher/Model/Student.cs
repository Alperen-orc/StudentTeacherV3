namespace StudentTeacher.Model
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string StudentSurname { get; set; }=string.Empty;
        public string StudentEmail { get; set; }=string.Empty;
        public int StudentNumber { get; set; }
        //public virtual Teacher Teacher { get; set;}
        //public int TeacherId { get; set; }
    }
    
}

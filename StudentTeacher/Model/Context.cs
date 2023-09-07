using Microsoft.EntityFrameworkCore;

namespace StudentTeacher.Model
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=213.238.168.103;Database=StjDB; User Id=stj;Password=3bOBS12Uk4g5JGs;");
            //Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;

        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<TeacherStudent> TeacherStudents { get; set; }
    }
}

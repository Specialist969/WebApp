using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static WebApp.Models.StudentDTO;

namespace WebApp
{
    public class StudentContext : IdentityDbContext<UserEntity, UserRole, int>
    {
        public StudentContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Student { get; set; } = null!;

  
    }
}

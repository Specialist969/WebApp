using Microsoft.AspNetCore.Identity;

namespace WebApp.Models
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

		public class UserRole : IdentityRole<int>
		{

		}

		public class UserEntity : IdentityUser<int>
		{

		}
	}
}

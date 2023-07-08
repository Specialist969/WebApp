using Microsoft.AspNetCore.Identity;

namespace WebApp
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Password { get; set; }

		
	}
}

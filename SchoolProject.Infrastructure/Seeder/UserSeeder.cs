using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Identity;

namespace SchoolProject.Infrastructure.Seeder
{
	public static class UserSeeder
	{
		public static async Task SeedAsync(UserManager<User> _userManager)
		{
			var usersCount = await _userManager.Users.CountAsync();
			if (usersCount <= 0)
			{
				var defaultuser = new User()
				{
					UserName = "admin",
					Email = "admin@project.com",
					FullName = "schoolProject",
					Country = "Egypt",
					PhoneNumber = "123456",
					Address = "Egypt",
					EmailConfirmed = true,
					PhoneNumberConfirmed = true
				};
				await _userManager.CreateAsync(defaultuser, "string12@S");
				await _userManager.AddToRoleAsync(defaultuser, "Admin");
			}
		}
	}
}

using SchoolProject.Data.Helpers;
using SchoolProject.Data.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace SchoolProject.Service.Abstractions
{
	public interface IAuthenticationService
	{
		public Task<JwtAuthResult> GenerateJWTTokenAsync(User user);
		public Task<JwtAuthResult> GetRefreshToken(User user, JwtSecurityToken jwtToken, DateTime? expiryDate, string refreshToken);
		public Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string AccessToken, string RefreshToken);
		public JwtSecurityToken ReadJWTToken(string accessToken);
		public Task<string> ValidateToken(string AccessToken);
		public Task<string> ConfirmEmail(int? userId, string? code);
	}
}

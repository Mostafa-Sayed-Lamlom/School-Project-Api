using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Helpers;
using SchoolProject.Data.Identity;
using SchoolProject.Service.Abstractions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolProject.Service.Implementations
{
	public class AuthenticationService : IAuthenticationService
	{
		#region Fields
		private readonly jwtSettings _jwtSettings;
		#endregion

		#region Constructors
		public AuthenticationService(jwtSettings jwtSettings)
		{
			_jwtSettings = jwtSettings;
		}
		#endregion

		#region Handle Functions
		public async Task<string> GenerateJWTTokenAsync(User user)
		{
			var claims = new List<Claim>()
			{
				new Claim("UserName", user.UserName),
				new Claim("UserEmail", user.Email)
			};

			var jwtToken = new JwtSecurityToken(
				_jwtSettings.Issuer,
				_jwtSettings.Audience,
				claims,
				expires: DateTime.Now.AddDays(_jwtSettings.AccessTokenExpireDate),
				signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
			var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
			return accessToken;
		}
		#endregion

	}
}

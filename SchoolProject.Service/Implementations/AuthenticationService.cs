using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;
using SchoolProject.Data.Identity;
using SchoolProject.Infrastructure.Abstractions;
using SchoolProject.Service.Abstractions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SchoolProject.Service.Implementations
{
	public class AuthenticationService : IAuthenticationService
	{
		#region Fields
		private readonly jwtSettings _jwtSettings;
		private readonly UserManager<User> _userManager;
		private readonly IUserRefreshTokenRepository _userRefreshTokenRepository;
		#endregion

		#region Constructors
		public AuthenticationService(jwtSettings jwtSettings,
									 UserManager<User> userManager,
									 IUserRefreshTokenRepository userRefreshTokenRepository)
		{
			_jwtSettings = jwtSettings;
			_userRefreshTokenRepository = userRefreshTokenRepository;
			_userManager = userManager;
		}
		#endregion

		#region Handle Functions
		public async Task<JwtAuthResult> GenerateJWTTokenAsync(User user)
		{
			var (jwtToken, accessToken) = await GetJwtToken(user);

			var refreshToken = new RefreshToken
			{
				UserName = user.UserName,
				ExpireAt = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
				TokenString = GenerateRefreshToken()
			};


			var userRefreshToken = new UserRefreshToken
			{
				AddedTime = DateTime.Now,
				ExpiryDate = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
				IsUsed = true,
				IsRevoked = false,
				JwtId = jwtToken.Id,
				RefreshToken = refreshToken.TokenString,
				Token = accessToken,
				UserId = user.Id
			};
			await _userRefreshTokenRepository.AddAsync(userRefreshToken);


			var jwtAuthResult = new JwtAuthResult();
			jwtAuthResult.AccessToken = accessToken;
			jwtAuthResult.refreshToken = refreshToken;
			return jwtAuthResult;
		}

		public async Task<JwtAuthResult> GetRefreshToken(User user, JwtSecurityToken jwtToken, DateTime? expiryDate, string refreshToken)
		{
			var (jwtSecurityToken, newToken) = await GetJwtToken(user);
			var response = new JwtAuthResult();
			response.AccessToken = newToken;
			var refreshTokenResult = new RefreshToken();
			refreshTokenResult.UserName = jwtToken.Claims.FirstOrDefault(x => x.Type == "UserName").Value;
			refreshTokenResult.TokenString = refreshToken;
			refreshTokenResult.ExpireAt = (DateTime)expiryDate;
			response.refreshToken = refreshTokenResult;
			return response;

		}

		public JwtSecurityToken ReadJWTToken(string accessToken)
		{
			if (string.IsNullOrEmpty(accessToken))
			{
				throw new ArgumentNullException(nameof(accessToken));
			}
			var handler = new JwtSecurityTokenHandler();
			var response = handler.ReadJwtToken(accessToken);
			return response;
		}

		public async Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string accessToken, string refreshToken)
		{
			if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
			{
				return ("AlgorithmIsWrong", null);
			}
			if (jwtToken.ValidTo > DateTime.UtcNow)
			{
				return ("TokenIsNotExpired", null);
			}

			//Get User

			var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == "UserId").Value;
			//var userId = "3";
			var userRefreshToken = await _userRefreshTokenRepository.GetTableNoTracking()
											 .FirstOrDefaultAsync(x => x.Token == accessToken &&
																	 x.RefreshToken == refreshToken &&
																	 x.UserId == int.Parse(userId));
			if (userRefreshToken == null)
			{
				return ("RefreshTokenIsNotFound", null);
			}

			if (userRefreshToken.ExpiryDate < DateTime.UtcNow)
			{
				userRefreshToken.IsRevoked = true;
				userRefreshToken.IsUsed = false;
				await _userRefreshTokenRepository.UpdateAsync(userRefreshToken);
				return ("RefreshTokenIsExpired", null);
			}
			var expirydate = userRefreshToken.ExpiryDate;
			return (userId, expirydate);
		}

		public async Task<string> ValidateToken(string accessToken)
		{
			var handler = new JwtSecurityTokenHandler();
			var parameters = new TokenValidationParameters
			{
				ValidateIssuer = _jwtSettings.ValidateIssuer,
				ValidIssuers = new[] { _jwtSettings.Issuer },
				ValidateIssuerSigningKey = _jwtSettings.ValidateIssuerSigningKey,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)),
				ValidAudience = _jwtSettings.Audience,
				ValidateAudience = _jwtSettings.ValidateAudience,
				ValidateLifetime = _jwtSettings.ValidateLifeTime,
			};
			try
			{
				var validator = handler.ValidateToken(accessToken, parameters, out SecurityToken validatedToken);

				if (validator == null)
				{
					return "InvalidToken";
				}

				return "NotExpired";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
		#endregion
		private string GenerateRefreshToken()
		{
			var randomNumber = new byte[32];
			var randomNumberGenerator = RandomNumberGenerator.Create();
			randomNumberGenerator.GetBytes(randomNumber);
			return Convert.ToBase64String(randomNumber);
		}

		private async Task<(JwtSecurityToken, string)> GetJwtToken(User user)
		{
			var claims = new List<Claim>()
			{
				new Claim("UserId", user.Id.ToString()),
				new Claim("UserName", user.UserName),
				new Claim("UserEmail", user.Email),

			};
			var roles = await _userManager.GetRolesAsync(user);
			foreach (var role in roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role));
			}

			var jwtToken = new JwtSecurityToken(
				_jwtSettings.Issuer,
				_jwtSettings.Audience,
				claims,
				expires: DateTime.Now.AddDays(_jwtSettings.AccessTokenExpireDate),
				signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
			var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
			return (jwtToken, accessToken);
		}
	}
}

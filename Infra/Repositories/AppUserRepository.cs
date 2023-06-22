using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using Infra.Context;
using Infra.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Infra.Repositories
{
    public class UserRepository : Repository<AppUser>, IUserRepository
    {
        private IConfiguration _configuration;
        public UserRepository(AppDbContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _configuration = configuration;
        }

        public async Task<AppUser> GetByEmailAsync(string email)
        {
            var user = await _dbSet.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                throw new NotFoundException($"Not found any user with this email - {email}");
            }
            return user;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var existUser = await GetByEmailAsync(email);

            if (existUser == null)
            {
                throw new NotFoundException($"Not found any user with this email - {email}");
            }

            if (PasswordServices.VerifyPassword(password, existUser.Password) == false)
            {
                throw new UnauthorizedException("Email or Password was invalid");
            }

            if (existUser.TwoFactor)
            {
                return GenerateCode();
            }

            return GenerateToken();
        }

        private string GenerateCode()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }

        private string GenerateToken()
        {
            var authSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(1),
                claims: new List<Claim>(),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}

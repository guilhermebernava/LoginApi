using Domain.DTOs;
using Domain.Entities;
using Domain.Redis;
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
        private ITwoFactorRedisRepository _twoFactorRedisRepository;
        public UserRepository(AppDbContext dbContext, IConfiguration configuration, ITwoFactorRedisRepository twoFactorRedisRepository) : base(dbContext)
        {
            _configuration = configuration;
            _twoFactorRedisRepository = twoFactorRedisRepository;
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

        public async Task<LoginDto> LoginAsync(string email, string password)
        {
            var existUser = await GetByEmailAsync(email);
            var response = new LoginDto();

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
                var code = await GenerateCode(existUser);
                response.Code = code;
                return response;
            }

            var token =  GenerateToken();
            response.Token = token;
            return response;
        }

        public async Task<string> TwoFactorAsync(string code)
        {
            try
            {
                var result = await _twoFactorRedisRepository.GetByKey(code);

                if(result == null)
                {
                    throw new NotFoundException("Not found this code, invalid code");
                }

                return GenerateToken();
            }
            catch (Exception ex)
            {
                throw new RedisException(ex.Message);
            }
        }

        private async Task<string> GenerateCode(AppUser user)
        {
            var code = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            await _twoFactorRedisRepository.Add(code, new AppUserTwoFactor(user.Id, code));
            return code;
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

﻿using Domain.DTOs;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using Infra.Context;
using Infra.Exceptions;
using Infra.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
            var user = await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                throw new NotFoundException($"Not found any user with this email - {email}");
            }
            return user;
        }

        public async Task<LoginDto> LoginAsync(string email, string password)
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
            var response = new LoginDto(existUser);

            if (existUser.TwoFactor)
            {
                response.Code = true;
                return response;
            }

            var token = JwtUtils.GenerateToken(_configuration,existUser);
            response.Token = token;
            return response;
        }

        public async Task UpdatePasswordAsync(string newPassword,string email)
        {
            var existUser = await GetByEmailAsync(email);
            if (existUser == null)
            {
                throw new NotFoundException($"Not found any user with this email - {email}");
            }
            existUser.Password = PasswordServices.EncryptPassword(newPassword);
            await SaveAsync();
        }
    }
}

using System;
using AutoMapper;
using employee_management_backend2.Data;
using employee_management_backend2.DTOs.auth;
using employee_management_backend2.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace employee_management_backend2.Services.Impl;

public class AuthService : IAuthService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly IConfiguration _configuration;

    public AuthService(IMapper mapper, DataContext context, IConfiguration configuration)
    {
        _mapper = mapper;
        _context = context;
        _configuration = configuration;
    }

    public async Task<ServiceResponse<AuthResDTO>> Login(AuthReqDTO request)
    {
        var serviceResponse = new ServiceResponse<AuthResDTO>();
        try
        {
            var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (dbUser == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Email not found.";
                return serviceResponse;
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, dbUser.Password))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Wrong password.";
                return serviceResponse;
            }

            var token = GenerateToken(dbUser);
            var authResponse = new AuthResDTO
            {
                Token = token,
                FirstName = dbUser.FirstName,
                LastName = dbUser.LastName,
                Email = dbUser.Email,
                UserName = dbUser.UserName
            };
            serviceResponse.Data = authResponse;
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    private string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(_configuration["AppSettings:Token"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, "Admin"), // Example role: "Admin"
            new Claim(ClaimTypes.Role, "Customer"), // Example role: "Customer"
            // Add more roles if needed
        }),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha512)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }


}


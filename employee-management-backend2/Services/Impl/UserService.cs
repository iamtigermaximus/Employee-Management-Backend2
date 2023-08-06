using System;
using AutoMapper;
using employee_management_backend2.Data;
using employee_management_backend2.DTOs.user;
using employee_management_backend2.Models;
using Microsoft.EntityFrameworkCore;

namespace employee_management_backend2.Services.Impl;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public UserService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ServiceResponse<List<UserResDTO>>> GetAllUsers()
    {
        var serviceResponse = new ServiceResponse<List<UserResDTO>>();
        var dbUsers = await _context.Users.ToListAsync();

        serviceResponse.Data = dbUsers.Select(u => _mapper.Map<UserResDTO>(u)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<UserResDTO>> GetUserById(string userId)
    {
        var serviceResponse = new ServiceResponse<UserResDTO>();
        try
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"User with Id '{userId}' not found.";
                return serviceResponse;
            }

            serviceResponse.Data = _mapper.Map<UserResDTO>(user);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<UserResDTO>> CreateUser(UserReqDTO newUser)
    {
        var serviceResponse = new ServiceResponse<UserResDTO>();
        try
        {
            var user = _mapper.Map<User>(newUser);

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(newUser.Password);
            user.Email = newUser.Email;
            user.Password = passwordHash;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<UserResDTO>(user);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<UserResDTO>> UpdateUser(UserReqDTO updatedUser)
    {
        var serviceResponse = new ServiceResponse<UserResDTO>();
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == updatedUser.Id);

            if (user == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"User with Id '{updatedUser.Id}' not found.";
                return serviceResponse;
            }

            _mapper.Map(updatedUser, user);
            await _context.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<UserResDTO>(user);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<UserResDTO>>> DeleteUser(string userId)
    {
        var serviceResponse = new ServiceResponse<List<UserResDTO>>();
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"User with Id '{userId}' not found.";
                return serviceResponse;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            var dbUsers = await _context.Users.ToListAsync();
            serviceResponse.Data = dbUsers.Select(u => _mapper.Map<UserResDTO>(u)).ToList();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

}


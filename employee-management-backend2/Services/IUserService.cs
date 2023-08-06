using System;
using employee_management_backend2.DTOs.user;
using employee_management_backend2.Models;

namespace employee_management_backend2.Services;

public interface IUserService
{
    Task<ServiceResponse<List<UserResDTO>>> GetAllUsers();
    Task<ServiceResponse<UserResDTO>> GetUserById(string userId);
    Task<ServiceResponse<UserResDTO>> CreateUser(UserReqDTO newUser);
    Task<ServiceResponse<UserResDTO>> UpdateUser(UserReqDTO updatedUser);
    Task<ServiceResponse<List<UserResDTO>>> DeleteUser(string userId);
}


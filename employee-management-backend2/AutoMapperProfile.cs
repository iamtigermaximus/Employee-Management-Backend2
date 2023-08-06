using System;
using AutoMapper;
using employee_management_backend2.DTOs.department;
using employee_management_backend2.DTOs.jobtitle;
using employee_management_backend2.DTOs.user;
using employee_management_backend2.Models;

namespace employee_management_backend2;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        //CreateMap<Employee, EmployeeReqDTO>();
        //CreateMap<EmployeeReqDTO, Employee>();
        //CreateMap<Employee, EmployeeResDTO>();

        CreateMap<Department, DepartmentReqDTO>();
        CreateMap<DepartmentReqDTO, Department>();
        CreateMap<Department, DepartmentResDTO>();

        CreateMap<JobTitle, JobTitleReqDTO>();
        CreateMap<JobTitleReqDTO, JobTitle>();
        CreateMap<JobTitle, JobTitleResDTO>();

        CreateMap<User, UserReqDTO>();
        CreateMap<UserReqDTO, User>();
        CreateMap<User, UserResDTO>();

        //CreateMap<User, AuthReqDTO>();
        //CreateMap<AuthReqDTO, User>();
        //CreateMap<User, AuthResDTO>();
    }
}


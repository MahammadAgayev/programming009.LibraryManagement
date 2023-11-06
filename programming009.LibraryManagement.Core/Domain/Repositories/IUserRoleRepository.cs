﻿using programming009.LibraryManagement.Core.Domain.Entities;

namespace programming009.LibraryManagement.Core.Domain.Repositories
{
    public interface IUserRoleRepository
    {

        void Add(UserRole userRole); 
        List<UserRole> GetByUserId(int userId);
        List<UserRole> GetByRoleId(int roleId);
    }
}
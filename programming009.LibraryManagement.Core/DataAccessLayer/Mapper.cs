﻿using Microsoft.Data.SqlClient;

using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Core.Domain.Enums;

using System.Data;

namespace programming009.LibraryManagement.Core.DataAccessLayer
{
    public static class Mapper
    {
        public static Branch MapBranch(IDataReader reader)
        {
            return new Branch
            {
                Name = (string)reader["Name"],
                Id = (int)reader["Id"],
                Address = (string)reader["Address"],
            };
        }

        public static Author MapAuthor(IDataReader reader)
        {
            return new Author
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Surname = (string)reader["Surname"]
            };
        }

        public static Book MapBook(IDataReader reader)
        {
            return new Book
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Price = (decimal)reader["Price"],
                Genre = (Genre)reader["Genre"]
            };
        }

        public static AuthorBook MapAuthorBook(IDataReader reader)
        {
            return new AuthorBook
            {
                Id = (int)reader["Id"],
                AuthorId = (int)reader["AuthorId"],
                Author = new Author
                {
                    Id = (int)reader["AuthorId"],
                    Name = (string)reader["AuthorName"],
                    Surname = (string)reader["AuthorSurname"]
                },
                BookId = (int)reader["BookId"],
                Book = new Book
                {
                    Id = (int)reader["BookId"],
                    Name = (string)reader["BookName"],
                    Price = (decimal)reader["Price"],
                    Genre = (Genre)reader["Genre"]
                }
            };
        }

        public static User MapUser(IDataReader reader)
        {
            return new User
            {
                Username = (string)reader["username"],
                Email = (string)reader["email"],
                PasswordHash = (string)reader["passwordhash"]
            };
        }

        public static UserRole MapUserRole(IDataReader reader)
        {
            return new UserRole
            {
                Id = (int)reader["Id"],
                RoleId = (int)reader["RoleId"],
                UserId = (int)reader["UserId"],
                User = new User
                {
                    Id = (int)reader["UserId"],
                    Email = (string)reader["email"],
                    PasswordHash = (string)reader["Passwordhash"],
                    Username = (string)reader["Username"]
                }
            };
        }
    }
}

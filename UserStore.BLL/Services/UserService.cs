﻿using Forum_Marchuk.BLL.DTO;
using Forum_Marchuk.BLL.Infrastructure;
using Forum_Marchuk.DAL.Entities;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using Forum_Marchuk.BLL.Interfaces;
using Forum_Marchuk.DAL.Interfaces;
using System.Collections.Generic;

namespace Forum_Marchuk.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                await Database.UserManager.CreateAsync(user, userDto.Password);
                
                await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                
                ClientProfile clientProfile = new ClientProfile { Id = user.Id, Age = userDto.Age, Name = userDto.Name };
                Database.ClientManager.Create(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Ви успішно зареєструвалися", "");

            }
            else
            {
                return new OperationDetails(false, "Користувач з таким логіном уже зареєстрований", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            
            ApplicationUser user = await Database.UserManager.FindAsync(userDto.Email, userDto.Password);
            
            if(user!=null)
                claim= await Database.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        
        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }

            await Create(adminDto);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }

    
}

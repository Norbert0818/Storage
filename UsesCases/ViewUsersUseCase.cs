﻿using CoreBuisness;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases
{
    public class ViewUsersUseCase : IViewUsersUseCase
    {
        private readonly IUserRepository userRepository;

        public ViewUsersUseCase(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<IdentityUser> Execute()
        {
            return userRepository.GetUsers();
        }
    }
}
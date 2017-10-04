﻿using CarModsHeaven.Data.Models;
using CarModsHeaven.Web.Infrastructure;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace CarModsHeaven.Web.Models.UsersList
{
    public class UserViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        [Display(Name = "Project Title")]
        public string UserName { get; set; }

        [Display(Name = "Car Brand")]
        public string Email { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<User, UserViewModel>()
                .ForMember(userViewModel => userViewModel.UserName, cfg => cfg.MapFrom(user => user.UserName))
                .ForMember(userViewModel => userViewModel.Email, cfg => cfg.MapFrom(user => user.Email));
        }
    }
}
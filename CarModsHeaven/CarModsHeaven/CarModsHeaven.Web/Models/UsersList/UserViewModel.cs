﻿using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Web.Infrastructure;
using System.Collections.Generic;

namespace CarModsHeaven.Web.Models.UsersList
{
    public class UserViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        [Display(Name = "Full Name")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        public ICollection<Project> Projects { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<User, UserViewModel>()
                .ForMember(userViewModel => userViewModel.UserName, cfg => cfg.MapFrom(user => user.UserName))
                .ForMember(userViewModel => userViewModel.Email, cfg => cfg.MapFrom(user => user.Email));
        }
    }
}
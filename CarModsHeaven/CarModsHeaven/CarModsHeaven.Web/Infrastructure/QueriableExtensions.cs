﻿using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper.QueryableExtensions;
using CarModsHeaven.Web.App_Start;

namespace CarModsHeaven.Web.Infrastructure
{
    public static class QueryableExtensions
    {
        public static IQueryable<TDestination> MapTo<TDestination>(this IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            return source.ProjectTo(AutoMapperConfig.Configuration, membersToExpand);
        }
    }
}
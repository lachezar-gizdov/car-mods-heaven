﻿using System.Security.Principal;
using System.Web;
using System.Web.Caching;
using CarModsHeaven.Providers.Contracts;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace FindAndBook.Providers
{
    public class HttpContextProvider : IHttpContextProvider
    {
        public HttpContext CurrentHttpContext
        {
            get
            {
                return HttpContext.Current;
            }
        }

        public IOwinContext CurrentOwinContext
        {
            get
            {
                return HttpContext.Current.GetOwinContext();
            }
        }

        public IIdentity CurrentIdentity
        {
            get
            {
                return HttpContext.Current.User.Identity;
            }
        }

        public Cache ContextCache
        {
            get
            {
                return HttpContext.Current.Cache;
            }
        }

        public TManager GetUserManager<TManager>()
        {
            return HttpContext.Current.GetOwinContext().GetUserManager<TManager>();
        }
    }
}
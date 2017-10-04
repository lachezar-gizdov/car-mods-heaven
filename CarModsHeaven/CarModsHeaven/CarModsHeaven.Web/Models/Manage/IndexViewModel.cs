using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace CarModsHeaven.Web.Models.Manage
{
    public class IndexViewModel
    {
        public string FullName { get; set; }

        public bool HasPassword { get; set; }

        public IList<UserLoginInfo> Logins { get; set; }

        public string PhoneNumber { get; set; }

        public bool TwoFactor { get; set; }

        public bool BrowserRemembered { get; set; }
    }
}
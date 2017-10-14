using System;
using CarModsHeaven.Data.Models.Contracts;

namespace CarModsHeaven.Data.Tests.EfRepositoryTests.Fake
{
    public class FakeEFRepository : IDeletable, IAuditable
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}

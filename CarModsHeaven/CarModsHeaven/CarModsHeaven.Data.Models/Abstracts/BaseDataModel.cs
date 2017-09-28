using CarModsHeaven.Data.Models.Contracts;
using System;

namespace CarModsHeaven.Data.Models.Abstracts
{
    public abstract class BaseDataModel : IDeletable, IAuditable
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}

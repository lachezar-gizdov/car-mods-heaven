using CarModsHeaven.Data.Models.Contracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarModsHeaven.Data.Models.Abstracts
{
    public abstract class BaseDataModel : IDeletable, IAuditable
    {
        public BaseDataModel()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }
    }
}

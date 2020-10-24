using AutoLotDAL.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoLotDAL.Models.DTO
{
    class CustomerDto : EntityBase
    {
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public virtual ICollection<OrderDto> Orders { get; set; } = new HashSet<OrderDto>();
    }
}

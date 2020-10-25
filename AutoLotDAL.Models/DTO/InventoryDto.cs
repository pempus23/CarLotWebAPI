using AutoLotDAL.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoLotDAL.Models.DTO
{
    public class InventoryDto : EntityBase
    {
        [StringLength(50)]
        public string Make { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(50)]
        public string PetName { get; set; }
        public virtual ICollection<OrderDto> Orders { get; set; }
    = new HashSet<OrderDto>();
    }
}


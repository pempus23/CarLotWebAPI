﻿using AutoLotDAL.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace AutoLotDAL.Models.DTO
{
    class InventoryDto : EntityBase
    {
        [StringLength(50)]
        public string Make { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(50)]
        public string PetName { get; set; }
    }
}

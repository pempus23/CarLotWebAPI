using AutoLotDAL.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDAL.Models.DTO
{
    public class OrderDto : EntityBase
    {
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(CarId))]
        public virtual Inventory Car { get; set; }
    }
}

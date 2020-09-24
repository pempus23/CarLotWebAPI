using System.ComponentModel.DataAnnotations;

namespace AutoLotDAL.Models.Base
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}

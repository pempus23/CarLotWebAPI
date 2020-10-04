using AutoLotDAL.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AutoLotDAL.Repos
{
    public class InventoryRepo : BaseRepo<Inventory>
    {
        public override List<Inventory> GetAll() 
            => Context.Cars.OrderBy(x=>x.Id).ToList();
        public List<Inventory> GetNotAll(int id)
        {
            return (Context.Cars.Where(c => c.Id == id).ToList());
        }
        public new int Delete(int id)
        {
            Inventory car = Context.Cars.FirstOrDefault(row => row.Id == id);
            IQueryable<Order> ord = Context.Orders.Where(c => c.CarId == id); 
            _table.Remove(car);
            if (ord.Count() > 0)
            {
                Context.Orders.RemoveRange(ord);
            }

            return SaveChanges();   
        }
    }
}

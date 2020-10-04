using AutoLotDAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace AutoLotDAL.Repos
{
    public class CustomerRepo : BaseRepo<Customer>
    {
        public override List<Customer> GetAll()
           => Context.Customers.OrderBy(x => x.FirstName).ToList();
        public List<Customer> GetNotAll(int id)
        {
            return (Context.Customers.Where(c => c.Id == id).ToList());
        }
        public List<Customer> GetCustomers(int id)
        {            
            var query = Context.Customers.Where(p => p.Orders.Any(t => t.Car.Id == id));
            return (query.ToList());
        }
    }
}

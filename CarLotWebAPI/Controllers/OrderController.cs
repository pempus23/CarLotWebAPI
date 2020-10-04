using AutoLotDAL.Models;
using AutoLotDAL.Repos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace CarLotWebAPI.Controllers
{
    [RoutePrefix("api/Order")]
    public class OrderController : ApiController
    {
        static IMapper mapper;
        static OrderController()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Customer, Customer>()
                .ForMember(x => x.Orders, opt => opt.Ignore());
            });
            mapper = config.CreateMapper();

        }
        private readonly CustomerRepo _Custrepo = new CustomerRepo();

        [HttpGet, Route("{id}", Name = "DisplayCust")]
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> GetOrder(int id)
        {
            
            List<Customer> order = _Custrepo.GetCustomers(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map< List<Customer>, List<Customer>>(order));
        }
    }
}

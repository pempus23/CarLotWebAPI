using AutoLotDAL.Models;
using AutoLotDAL.Repos;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Http;

namespace CarLotWebAPI.Controllers
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        static IMapper mapper;
        static CustomerController()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Customer, Customer>()
                .ForMember(x => x.Orders, opt => opt.Ignore());
            });
            mapper = config.CreateMapper();

        }
        private readonly CustomerRepo _Custrepo = new CustomerRepo();

        [HttpGet, Route("")]
        public IEnumerable<Customer> GetCustomers()
        {
             
            var customers = _Custrepo.GetAll();
            return mapper.Map<List<Customer>, List<Customer>>(customers);
        }

    }
}

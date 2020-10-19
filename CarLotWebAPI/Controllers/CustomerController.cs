using AutoLotDAL.Models;
using AutoLotDAL.Repos;
using AutoLotDAL.Repos.Templates;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace CarLotWebAPI.Controllers
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        private readonly IGetList<Customer> _repository;
        public CustomerController(IGetList<Customer> repository)
        {
            _repository = repository;
        }
        static IMapper mapper;
        static CustomerController()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Customer, Customer>()
                .ForMember(x => x.Orders, opt => opt.Ignore());
            });
            mapper = config.CreateMapper();

        }

        [HttpGet, Route("")]
        public IEnumerable<Customer> GetCustomers()
        {
             
            List<Customer> customers = _repository.GetAll();
            return mapper.Map<List<Customer>, List<Customer>>(customers);
        }

        [HttpGet, Route("{id}", Name = "DisplayCust")]
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> GetOrder(int id)
        {
            List<Customer> order = _repository.GetOne(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<List<Customer>, List<Customer>>(order));
        }

    }
}

using AutoLotDAL.Models;
using AutoLotDAL.Models.DTO;
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
        private readonly IMapper _mapper;
        public CustomerController(IGetList<Customer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet, Route("")]
        public IEnumerable<CustomerDto> GetCustomers()
        {
             
            List<Customer> customers = _repository.GetAll();
            return _mapper.Map<List<CustomerDto>>(customers);
        }

        [HttpGet, Route("{id}", Name = "DisplayCust")]
        [ResponseType(typeof(OrderDto))]
        public async Task<IHttpActionResult> GetOrder(int id)
        {
            List<Customer> order = _repository.GetOne(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<OrderDto>>(order));
        }

    }
}

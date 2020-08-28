using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoLotDAL.Models;
using AutoLotDAL.Repos;
using AutoMapper;

namespace CarLotWebAPI.Controllers
{
    [RoutePrefix("api/Inventory")]
    public class InventoryController : ApiController
    {
        static IMapper mapper;
        static InventoryController()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Inventory, Inventory>()
                .ForMember(x => x.Orders, opt => opt.Ignore());
            });
            mapper = config.CreateMapper();

        }

        private readonly InventoryRepo _repo = new InventoryRepo();

        //[HttpGet, Route("")]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "Value2" };
        //}

        ////GET api/values/5
        //public string Get (int id)
        //{
        //    return id.ToString();
        //}

        //GET: api/Inventory
        [HttpGet, Route("")]
        public IEnumerable<Inventory> GetInventory()
        {
            var inventories = _repo.GetAll();
            return mapper.Map<List<Inventory>,List <Inventory>>(inventories);
        }

        //GET: api/Inventory/5
        [HttpGet, Route("{id}", Name = "DisplayRoute")]
        [ResponseType(typeof(Inventory))]
        public async Task<IHttpActionResult> GetInventory(int id)
        {
            Inventory inventory = _repo.GetOne(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Inventory, Inventory>(inventory));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
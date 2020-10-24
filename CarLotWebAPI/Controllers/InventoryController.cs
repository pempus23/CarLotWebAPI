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
        private readonly IExtendRepository<Inventory> _repository;
        private  IMapper _mapper;

        //static IMapper mapper;
        //static InventoryController()
        //{
        //    var config = new MapperConfiguration(cfg => {
        //        cfg.CreateMap<Inventory, Inventory>()
        //        .ForMember(x => x.Orders, opt => opt.Ignore());
        //    });
        //    mapper = config.CreateMapper();

        //}

        public InventoryController(IExtendRepository<Inventory> repository, IMapper mapper)
        {
            _repository = repository;
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Inventory, Inventory>()
                .ForMember(x => x.Orders, opt => opt.Ignore());
            });
            mapper = config.CreateMapper();
            _mapper = mapper;

        }


        [HttpGet, Route("")]
        public IEnumerable<Inventory> GetInventory()
        {
            var inventories = _repository.GetAll();
            return _mapper.Map<List<Inventory>, List<Inventory>> (inventories);
        }

        //GET: api/Inventory/5
        [HttpGet, Route("{id}", Name = "DisplayRoute")]
        [ResponseType(typeof(Inventory))]
        public async Task<IHttpActionResult> GetInventory(int id)
        {
            Inventory inventory = _repository.GetOne(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Inventory, Inventory>(inventory));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }

        //PUT: api/Inventory
        [HttpPut, Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInventory(int id, Inventory inventory)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != inventory.Id)
            {
                return BadRequest();
            }
            try
            {
                _repository.Save(inventory);
            }
            catch(Exception ex)
            {
                //must be other actions
                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        //POST: api/inventory
        [HttpPost, Route("")]
        [ResponseType(typeof(Inventory))]
        public IHttpActionResult PostInventory(Inventory inventory)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _repository.Add(inventory);
            }
            catch(Exception ex)
            {
                //must be other actions
                throw;
            }
            return CreatedAtRoute("DisplayRoute", new { id = inventory.Id }, inventory);
        }

        //DELETE: api/Inventory/id
        [HttpDelete, Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteInventory(int id)
        { 
            try
            {
                _repository.Delete(id);
            }
            catch(Exception ex)
            {
                //must be other actions
                throw;
            }
            return Ok();
        }
    }
}
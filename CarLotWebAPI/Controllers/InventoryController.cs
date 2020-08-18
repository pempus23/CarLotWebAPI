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
        [HttpGet, Route("")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "Value2" };
        }

        //GET api/values/5
        public string Get (int id)
        {
            return id.ToString();
        }
    }
}
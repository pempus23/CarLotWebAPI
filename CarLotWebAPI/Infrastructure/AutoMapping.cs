using AutoLotDAL.Models;
using AutoLotDAL.Models.DTO;
using AutoMapper;
using System.Collections.Generic;

namespace CarLotWebAPI.Infrastructure
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Inventory, InventoryDto>().ForMember(x => x.Orders, opt => opt.Ignore());
            CreateMap<Customer, CustomerDto>().ForMember(x => x.Orders, opt => opt.Ignore());
            CreateMap<Customer, OrderDto>();
        }
    }
}
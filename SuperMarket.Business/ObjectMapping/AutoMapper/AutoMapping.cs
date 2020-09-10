using AutoMapper;
using SuperMarket.Associate.DTO;
using SuperMarket.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Business.ObjectMapping.AutoMapper
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<AppUser, AppUserDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<CartDTO, Cart>().ReverseMap();
            CreateMap<CartItemDTO, CartItem>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();

        }
    }
}

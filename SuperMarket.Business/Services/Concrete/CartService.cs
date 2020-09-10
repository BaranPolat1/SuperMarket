using AutoMapper;
using SuperMarket.Associate.DTO;
using SuperMarket.Business.Services.Abstract;
using SuperMarket.Business.UnitOfWork.Abstract;
using SuperMarket.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Business.Services.Concrete
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public CartService(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public CartDTO GetCart(int Id)
        {
            Cart cart = uow.Carts.GetWithCartItems(Id);
            CartDTO model = mapper.Map<CartDTO>(cart);
            return model;

        }
    }
}

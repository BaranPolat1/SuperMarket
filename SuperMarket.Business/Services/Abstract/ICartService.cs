using SuperMarket.Associate.DTO;
using SuperMarket.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Business.Services.Abstract
{
    public interface ICartService
    {
        public CartDTO GetCart(int Id);
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using SuperMarket.Associate.DTO;
using SuperMarket.Business.Services.Abstract;
using SuperMarket.Business.UnitOfWork.Abstract;
using SuperMarket.Entity.Entities;
using System;


namespace SuperMarket.Business.Services.Concrete
{
    public class AppUserService : IAppUserService
    {
        private readonly IUnitOfWork uow;
        
        public AppUserService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public AppUser getUser(string userName)
        {
            AppUser user = uow.AppUsers.Get(x => x.UserName == userName);
            return user;
        }

        public string Login(AppUserDTO model)
        {
            AppUser user = uow.AppUsers.Get(x => x.UserName == model.UserName && x.Password == model.Password);
            if (user != null)
            {
                return user.UserName;
            }
            else
            {
                return "-1";
            }
        }


    }
}

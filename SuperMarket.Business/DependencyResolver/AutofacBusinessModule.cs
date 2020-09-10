using Autofac;
using SuperMarket.Business.Services.Abstract;
using SuperMarket.Business.Services.Concrete;
using SuperMarket.Business.UnitOfWork.Abstract;
using SuperMarket.DAL.Repository.Abstract;
using SuperMarket.DAL.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Business.DependencyResolver
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppUserRepoEF>().As<IAppUserRepo>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryRepoEF>().As<ICategoryRepo>().InstancePerLifetimeScope();
            builder.RegisterType<ProductRepoEF>().As<IProductRepo>().InstancePerLifetimeScope();
            builder.RegisterType<OrderDetailRepoEF>().As<IOrderDetailRepo>().InstancePerLifetimeScope();
            builder.RegisterType<OrderRepoEF>().As<IOrderRepo>().InstancePerLifetimeScope();
            builder.RegisterType<CartRepoEF>().As<ICartRepo>().InstancePerLifetimeScope();
            builder.RegisterType<CartItemRepoEF>().As<ICartItemRepo>().InstancePerLifetimeScope();
            builder.RegisterType<AppUserService>().As<IAppUserService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<CartItemService>().As<ICartItemService>().InstancePerLifetimeScope();
            builder.RegisterType<CartService>().As<ICartService>().InstancePerLifetimeScope();
            builder.RegisterType<OrderService>().As<IOrderService>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork.Concrete.UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}

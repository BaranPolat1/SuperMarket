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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public CategoryService(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public bool AddCategory(CategoryDTO model)
        {
            try
            {
                Category item = mapper.Map<Category>(model);
                uow.Categories.Add(item);
                uow.SaveChange();
                return true;
            }
            catch (Exception)
            {
                return false;
               
            }
           
        }

        public IList<CategoryDTO> GetCategories()
        {
            IList<Category> categories = uow.Categories.GetList();
            IList<CategoryDTO> model = mapper.Map<IList<CategoryDTO>>(categories);
            return model;
        }
    }
}

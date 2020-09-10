using SuperMarket.Associate.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Business.Services.Abstract
{
    public interface ICategoryService
    {
        bool AddCategory(CategoryDTO model);
        IList<CategoryDTO> GetCategories();
    }
}


using SuperMarket.Associate.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Business.Services.Abstract
{
   public interface IProductService
    {
        IList<ProductDTO> GetProductList(int? sayfano, int pageSize);
        bool AddProduct(ProductDTO model);
        ProductDTO Get(int Id);
        bool DeleteProduct(int Id);
        bool EditProduct(ProductDTO model);
        IList<ProductDTO> GetList();

    }
}

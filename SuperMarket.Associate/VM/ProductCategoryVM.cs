using SuperMarket.Associate.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Associate.VM
{
    public class ProductCategoryVM
    {
        public IList<CategoryDTO> Categories { get; set; }
        public ProductDTO Product { get; set; }
    }
}

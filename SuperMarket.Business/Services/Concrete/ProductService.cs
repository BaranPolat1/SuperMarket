using AutoMapper;
using Omu.ValueInjecter;
using SuperMarket.Associate.DTO;
using SuperMarket.Business.ObjectMapping.ValueInjecter;
using SuperMarket.Business.Services.Abstract;
using SuperMarket.Business.UnitOfWork.Abstract;
using SuperMarket.Entity.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace SuperMarket.Business.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private IHostEnvironment _environment;
        public ProductService(IUnitOfWork uow, IMapper mapper, IHostEnvironment _environment)
        {
            this._environment = _environment;
            this.uow = uow;
            this.mapper = mapper;
        }
        public bool AddProduct(ProductDTO model)
        {
            try
            {
                if (model.ImageUpload != null)
                {
                    string uploadDir = Path.Combine(_environment.ContentRootPath, "wwwroot/media/pics");
                    if (!Directory.Exists(uploadDir))
                    {
                        Directory.CreateDirectory(uploadDir);
                    }
                    string fileName = Path.GetFileName(model.ImageUpload.FileName);
                    using (FileStream stream = new FileStream(Path.Combine(uploadDir, fileName), FileMode.Create))
                    {
                        model.ImageUpload.CopyTo(stream);
                        model.ImagePath = fileName;
                        stream.Close();
                    }
                }

                Product product = mapper.Map<Product>(model);
                uow.Products.Add(product);
                uow.SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteProduct(int Id)
        {
            Product product = uow.Products.Get(x => x.Id == Id);
            if (product != null)
            {
                uow.Products.Delete(product);
                uow.SaveChange();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditProduct(ProductDTO model)
        {
            try
            {
                Product product = uow.Products.Get(x => x.Id == model.Id);
                product.InjectFrom<FilterId>(model);
                uow.Products.Update(product);
                uow.SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public ProductDTO Get(int Id)
        {
            Product product = uow.Products.Get(x => x.Id == Id);
            ProductDTO model = mapper.Map<ProductDTO>(product);
            return model;
        }

        public IList<ProductDTO> GetList()
        {
            IList<Product> products = uow.Products.GetList();
            IList<ProductDTO> model = mapper.Map<IList<ProductDTO>>(products);
            return model;
        }

        public IList<ProductDTO> GetProductList(int? sayfano, int pageSize)
        {
            IList<ProductDTO> model = null;
            IList<Product> products = uow.Products.GetList();
            if (sayfano == null)
            {
                model = mapper.Map<IList<ProductDTO>>(products).Take(pageSize).ToList();
            }
            else
            {
                model = mapper.Map<IList<ProductDTO>>(products).Skip(pageSize * sayfano.Value).Take(pageSize).ToList();
            }
            return model;

        }
    }
}

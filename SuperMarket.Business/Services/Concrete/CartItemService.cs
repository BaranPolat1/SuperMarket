using AutoMapper;
using SuperMarket.Associate.DTO;
using SuperMarket.Associate.VM;
using SuperMarket.Business.Services.Abstract;
using SuperMarket.Business.UnitOfWork.Abstract;
using SuperMarket.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Business.Services.Concrete
{
    public class CartItemService : ICartItemService
    {
        private readonly IUnitOfWork uow;
        private IMapper mapper;
        public CartItemService(IUnitOfWork uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.uow = uow;
        }
        public JsonCartItemVM AddCartItem(int cartId, int productId, string price)
        {
            JsonCartItemVM model = new JsonCartItemVM();
            CartItem item = null;

            try
            {
                Product product = uow.Products.Get(x => x.Id == productId);
                if (product.Stock == 0)
                {
                    model.price = 0;
                    model.message = "Ürün stoğu bitti";
                    return model;
                }
                if (uow.CartItems.Any(x => x.CartId == cartId && x.ProductId == productId) && price != null)
                {
                    item = uow.CartItems.Get(x => x.CartId == cartId && x.ProductId == productId);
                    item.Quantity++;
                    item.TotalAmount += decimal.Parse(price);
                    product.Stock--;
                    uow.Products.Update(product);
                    uow.CartItems.Update(item);
                    uow.SaveChange();
                    model.price = product.Price;
                    model.lastPrice = item.TotalAmount;
                    model.message = "Ürün Sepete Eklendi";

                }
                else if (uow.CartItems.Any(x => x.CartId == cartId && x.ProductId == productId) && price == null)
                {
                    item = uow.CartItems.Get(x => x.CartId == cartId && x.ProductId == productId);
                    item.Quantity++;
                    item.TotalAmount += product.Price;
                    product.Stock--;
                    uow.Products.Update(product);
                    uow.CartItems.Update(item);
                    uow.SaveChange();
                    model.price = product.Price;
                    model.lastPrice = item.TotalAmount;
                    model.message = "Ürün Sepete Eklendi";
                }
                else
                {
                    item = new CartItem();
                    item.CartId = cartId;
                    item.ProductId = productId;
                    item.Quantity++;
                    item.TotalAmount = decimal.Parse(price);
                    product.Stock--;
                    uow.CartItems.Add(item);
                    uow.Products.Update(product);
                    uow.SaveChange();
                    model.price = product.Price;
                    model.lastPrice = item.TotalAmount;
                    model.message = "Ürün Sepete Eklendi";

                }
                return model;

            }
            catch (Exception ex)
            {
                model.message = ex.Message;
                return model;
            }
        }

        public JsonCartItemVM DeleteCartItem(int cartId, int productId, int quantity, string type)
        {
            JsonCartItemVM model = new JsonCartItemVM();
            try
            {
               
                Product product = uow.Products.Get(x => x.Id == productId);
                CartItem item = uow.CartItems.Get(x => x.ProductId == productId && x.CartId == cartId);

               
                if (quantity == 1 || type == "deleteAll")
                {
                    model.price = item.TotalAmount;
                    product.Stock += quantity;
                    uow.CartItems.Delete(item);
                }
                else
                {
                    product.Stock++;
                    item.Quantity--;
                    item.TotalAmount -= product.Price;
                    model.price = product.Price;
                    model.lastPrice = item.TotalAmount;
                    uow.CartItems.Update(item);
                }
                uow.Products.Update(product);
                uow.SaveChange();
                return model;

            }
            catch (Exception ex)
            {
                model.message = ex.Message;
                return model;
              

            }
        }

        public IList<CartItemDTO> GetCartItems(int cartId)
        {
            IList<CartItem> cartItems = uow.CartItems.GetCartItemsWithProduct(cartId);
            IList<CartItemDTO> model = mapper.Map<IList<CartItemDTO>>(cartItems);
            return model;

        }

        public decimal GetTotalAmount(int cartId)
        {
            decimal totalAmount = 0;
            IList<CartItem> cartItems = uow.CartItems.GetList(x => x.CartId == cartId);
            foreach (var item in cartItems)
            {
                totalAmount += item.TotalAmount;
            }
            return totalAmount;


        }
    }
}

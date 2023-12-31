﻿using advanded_csharp_database;
using advanded_csharp_database.Models;
using advanded_csharp_dto.Request;
using advanded_csharp_dto.Response;

namespace advanded_csharp_service.CartService
{
    public class CartService : ICartService
    {
        public async Task<ListProductInCartResponse> AddToCart(CartProductRequest request)
        {
            using (DataDbContext context = new())
            {
                if (context.Users != null && context.carts != null && context.Products != null)
                {
                    //Check cart
                    Cart? cart = context.carts.Find(request.UserId);

                    if (cart == null)
                    {
                        // if A user dont have any cart create new
                        bool i = await InsertCart(request);
                        if (i)
                        {
                            return await GetCart(request.UserId);
                        }
                    }
                    else if (request.ProductId != Guid.Empty)
                    {
                        //if A user have  cart update it
                        bool i = await UpdateCart(request);
                        if (i)
                        {
                            return await GetCart(request.UserId);
                        }
                    }
                    else
                    {
                        //if user just watch user's cart
                        return await GetCart(request.UserId);
                    }

                }
            }
            return await GetCart(request.UserId);
        }

        /// <summary>
        /// Insert cart if don't exeit 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<bool> InsertCart(CartProductRequest request)
        {

            DataDbContext context = new();
            if (context.carts != null)
            {
                Cart cart = new()
                {
                    Id = request.UserId,
                    ListProduct = request.ProductId.ToString()
                };
                _ = await context.carts.AddAsync(cart);
                int i = await context.SaveChangesAsync(); //save change trả về int
                return i > 0;
            }
            return false;
        }

        /// <summary>
        /// Get data cart
        /// </summary>
        /// <param name="cardId"></param>
        /// <returns></returns>
        public Task<ListProductInCartResponse> GetCart(Guid cardId)
        {

            ListProductInCartResponse listProductInCartResponse = new()
            {
                PageSize = 10,
                PageIndex = 1
            };
            using (DataDbContext context = new())
            {
                if (context.carts != null)
                {
                    Cart? cart = context.carts.Find(cardId);
                    if (cart != null)
                    {
                        CartResponse cartResponse = cart.Transfrom();
                        List<string> result = cartResponse.ListProduct.Split(',').ToList();
                        foreach (string id in result)
                        {
                            Guid ok = new(id);
                            if (context.Products != null)
                            {
                                Product? product = context.Products.Find(ok);
                                if (product != null)
                                {
                                    listProductInCartResponse.Data.Add(product.Transfrom());
                                }
                            }
                        }
                        listProductInCartResponse.TotalPay = (int)listProductInCartResponse.Data.Sum(p => double.Parse(p.Price));
                        listProductInCartResponse.Count = listProductInCartResponse.Data.Count;
                    }
                }
            }
            return Task.FromResult(listProductInCartResponse);
        }

        /// <summary>
        /// Update Cart if have been add
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<bool> UpdateCart(CartProductRequest request)
        {
            using DataDbContext context = new();
            if (context.carts != null)
            {
                Cart? cart = context.carts.Find(request.UserId);

                if (cart != null)
                {
                    if (cart.ListProduct == "")
                    {
                        string newProdcut = request.ProductId.ToString();
                        cart.ListProduct += newProdcut;

                    }
                    else
                    {
                        string newProdcut = "," + request.ProductId;
                        cart.ListProduct += newProdcut;

                    }

                    _ = context.carts.Update(cart);
                    _ = await context.SaveChangesAsync();
                    return await context.SaveChangesAsync() > 0;

                }
            }
            return false;
        }

        public async Task<ListProductInCartResponse> DeleteItemCart(CartProductRequest request)
        {
            using (DataDbContext context = new())
            {
                if (context.carts != null)
                {
                    Cart? cart = context.carts.Find(request.UserId);
                    if (cart != null)
                    {
                        CartResponse cartResponse = cart.Transfrom();
                        List<string> result = cartResponse.ListProduct.Split(',').ToList();
                        string guidString = request.ProductId.ToString();
                        _ = result.Remove(guidString);
                        string UpdateAfterDel = string.Join(",", result);
                        cart.ListProduct = UpdateAfterDel;
                        _ = context.carts.Update(cart);
                        _ = await context.SaveChangesAsync();

                    }
                }
            }
            return await GetCart(request.UserId);
        }



    }
}

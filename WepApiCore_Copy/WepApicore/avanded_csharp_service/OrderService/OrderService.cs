using advanded_csharp_database.Models;
using advanded_csharp_database;
using advanded_csharp_dto.Response;


namespace advanded_csharp_service.OrderService
{
    public class OrderService : IOrderService
    {
        public async Task<GetListOrderResponse> InsertOrder(Guid cartId)
        {
            GetListOrderResponse listOrderResponse = new()
            {
                PageSize = 10,
                PageIndex = 1
            };
            using (DataDbContext context = new())
            {
                // từ đậy Xử lý dữ liệu cart insert cho order và hiện data
                if (context.carts != null && context.orders != null)
                {
                    Cart? cart = context.carts.Find(cartId);
                    Order addOrder = new();
                    if (cart != null)
                    {
                        addOrder.ListProduct = cart.ListProduct;// 1 : Order->lấy giá trị listProduct
                        CartResponse cartResponse = cart.Transfrom(); // hứng list cart 
                        List<string> result = cartResponse.ListProduct.Split(',').ToList(); // xử lỷ string to list<string>
                        
                        //xử lý string trong cart (listProduct) và lấy giá trị sum(price) và count                 
                        List<ProductRespone> listProduct = new List<ProductRespone>();    
                        foreach (string id in result)
                        {
                            Guid ok = new Guid(id);
                            if (context.Products != null)
                            {
                                Product? product = context.Products.Find(ok);
                                if (product != null)
                                {    
                                    listProduct.Add(product.Transfrom());
                                    listOrderResponse.ListProduct.Add(product.Transfrom());// 1:  GetListOrderResponse -> get list Product in cart
                                }
                            }
                        }
                        listOrderResponse.Number= addOrder.Number = (short)listProduct.Count; //2 : order -> get count and 2: GetListOrderResponse -> get number
                        addOrder.Payment = (decimal)listProduct.Sum(pr => (double.Parse(pr.Price)/1000)); //3 : order-> get data Paymnet
                        listOrderResponse.Payment = addOrder.Payment.ToString();//4 : GetListOrderResponse-> get data paymnet
                        addOrder.UserID = cartId;// 4: order-> get order of USer
                        await context.orders.AddAsync(addOrder);
                        await context.SaveChangesAsync();
                    }
                    if(addOrder.ListProduct!=null && addOrder.ListProduct != "")
                    {
                        bool i = await DeleteListInCart(cartId);
                        if(i) { return await Task.FromResult(listOrderResponse); }
                    }
                }
                return await Task.FromResult(listOrderResponse);
            }
        }

        /// <summary>
        /// Delte lsit prodcut in cart after insert order
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteListInCart(Guid cartId)
        {
            using (DataDbContext context = new())
            {
                if (context.carts != null)
                {
                    Cart? cart = context.carts.Find(cartId);

                    if (cart != null)
                    {
                        cart.ListProduct = "";
                        context.carts.Update(cart);
                        await context.SaveChangesAsync();
                        return await context.SaveChangesAsync() > 0;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Get deatil order
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        public async Task<GetListOrderResponse> GetOrder(Guid OrderId)
        {
            GetListOrderResponse listOrderResponse = new()
            {
                PageSize = 10,
                PageIndex = 1
            };
            using (DataDbContext context = new())
            {
                if (context.orders != null && context.Users!=null)
                {
                    Order? order = context.orders.Find(OrderId);
                  
                    if (order != null)
                    {
                        User? user = context.Users.Find(order.UserID);
                        List<string> result = order.ListProduct.Split(',').ToList();
                        foreach (string id in result)
                        {
                            Guid ok = new Guid(id);
                            if (context.Products != null)
                            {
                                Product? product = context.Products.Find(ok);
                                if (product != null)
                                {
                                    listOrderResponse.ListProduct.Add(product.Transfrom());
                                }
                            }
                        }
                        listOrderResponse.Payment = order.Payment.ToString()+" "+"VND";
                        listOrderResponse.Number = order.Number;
                        if(user!=null) listOrderResponse.UserName = user.User_Name;
                    }
                }
            }
            return await Task.FromResult(listOrderResponse);
        }
    }
}

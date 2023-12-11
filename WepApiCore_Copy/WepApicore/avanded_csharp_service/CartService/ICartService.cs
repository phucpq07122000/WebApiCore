using advanded_csharp_dto.Request;
using advanded_csharp_dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advanded_csharp_service.CartService
{
    public interface ICartService
    {
        Task<ListProductInCartResponse> AddToCart(AddProductToCart request);

        Task<ListProductInCartResponse> GetCart(Guid cardId);

        //Task<CartResponse> UpdateCart(AddProductToCart request);
        
    }
}

using advanded_csharp_dto.Response;
using advanded_csharp_service.CartService;

namespace advanded_csharp_test
{
    [TestClass]
    public class CartTest
    {
        private readonly ICartService _iCartService;
        public CartTest()
        {
            _iCartService = new CartService();
        }

        [TestMethod]
        public async Task getCart()
        {
            //   string guild = "DB07579C-CED4-4D12-9883-0000E0FF4EDF";
            Guid id = new("23D1252A-4C8B-4786-4D7C-08DBFAC7B838");
            ListProductInCartResponse cartOfUserResponse = await _iCartService.GetCart(id);
            Assert.IsNotNull(cartOfUserResponse);
        }

    }
}

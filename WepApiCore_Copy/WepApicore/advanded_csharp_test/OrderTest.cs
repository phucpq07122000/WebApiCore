using advanded_csharp_dto.Response;
using advanded_csharp_service.OrderService;

namespace advanded_csharp_test
{
    [TestClass]
    public class OrderTest
    {
        private readonly IOrderService _iOrderService;

        public OrderTest()
        {
            _iOrderService = new OrderService();
        }

        [TestMethod]
        public async Task GetOrder()
        {
            Guid id = new("5DE38BD5-A9D6-438E-E9E3-08DBFAC4A641");
            GetListOrderResponse getListOrderResponse = await _iOrderService.InsertOrder(id);
            Assert.IsNotNull(getListOrderResponse);
        }
    }
}

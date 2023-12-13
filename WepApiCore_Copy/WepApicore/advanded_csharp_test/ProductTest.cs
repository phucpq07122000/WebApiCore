using advanded_csharp_service.Log4net;
using advanded_csharp_service.ProductService;
using advanded_csharp_service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using advanded_csharp_dto.Response;
using advanded_csharp_dto.Request;
using advanded_csharp_dto.DTOEnitity;

namespace advanded_csharp_test
{

    [TestClass]
    public class ProductTest
    {
   
        private readonly IProductService _iProductService;
        public ProductTest()
        {
            _iProductService = new ProductService();
        }

        /// <summary>
        /// Get List Product No Name
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestGetListProductAsyncNoName()
        {
            //input
            GetListProductRequest request =  new()
            {
                PageIndex = 1,
                PageSize = 10,
                ProductName = ""
            };

            // output
            GetDataProductResponse response = await _iProductService.GetProductList(request);
            Assert.IsNotNull(response); // response not null
            Assert.IsTrue(response.Data.Count > 0); // response data > 0
        }

        /// <summary>
        /// Get List Product  Name
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestGetListProductAsyncWithName()
        {
            //input
            GetListProductRequest request = new()
            {
                PageIndex = 1,
                PageSize = 10,
                ProductName = "Product 40183"
            };

            // output
            GetDataProductResponse response = await _iProductService.GetProductList(request);
            Assert.IsNotNull(response); // response not null
            Assert.IsTrue(response.Data.Count > 0); // response data > 0
        }

        /// <summary>
        /// Get List Product  Name
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestDetailProductAsync()
        {
            //input
            string guild = "DB07579C-CED4-4D12-9883-0000E0FF4EDF";
            Guid id = Guid.Parse(guild);

            // output
            ProductDto response = await _iProductService.GetDetailProduct(id);
            Assert.IsNotNull(response); // response not null        
            Assert.AreEqual(id, response.Id);   // response UserDetails > 0
        }

    }
}

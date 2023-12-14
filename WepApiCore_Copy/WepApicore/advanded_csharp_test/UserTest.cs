
using advanded_csharp_dto.Request;
using advanded_csharp_dto.Response;
using advanded_csharp_service.UserService;

namespace advanded_csharp_test
{
    [TestClass]
    public class UserTest
    {

        private readonly IUserService _iUserService;

        public UserTest()
        {
            _iUserService = new UserService();
        }

        /// <summary>
        /// Get List User with No Name
        /// </summary>
        [TestMethod]
        public async Task TestReturnUserListActiveAsyncNoName()
        {
            // Input
            GetListUserRequest request = new()
            {
                PageIndex = 1,
                PageSize = 10,
                UserName = ""
            };
            // Output
            UserListrResponse response = await _iUserService.GetUserListIsActive(request);
            Assert.IsNotNull(response); // response not null
            Assert.IsTrue(response.Data.Count > 0); // response data > 0
        }

        /// <summary>
        /// Get List User with Name
        /// </summary>
        [TestMethod]
        public async Task TestReturnUserListActiveAsyncWithName()
        {
            // Input
            GetListUserRequest request = new()
            {
                PageIndex = 1,
                PageSize = 10,
                UserName = "User4"
            };

            // Output
            UserListrResponse response = await _iUserService.GetUserListIsActive(request);
            Assert.IsNotNull(response); // response not null
            Assert.IsTrue(response.Data.Count >= 1); // response data > 0
        }

        /// <summary>
        /// Get List User with No Name
        /// </summary>
        [TestMethod]
        public async Task TestGetUserDetail()
        {
            // Input
            string guild = "CF4D31E3-1D34-4AAD-4D7B-08DBFAC7B838";
            Guid id = Guid.Parse(guild);

            // Output
            UserResponse response = await _iUserService.GetUserDetail(id);
            Assert.IsNotNull(response); // response not null        
            Assert.AreEqual(id, response.Id);   // response UserDetails > 0
        }
    }
}
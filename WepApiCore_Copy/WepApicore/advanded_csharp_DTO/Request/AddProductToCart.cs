namespace advanded_csharp_dto.Request
{
    public class AddProductToCart
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}

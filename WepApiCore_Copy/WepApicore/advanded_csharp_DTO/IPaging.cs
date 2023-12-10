namespace advanded_csharp_DTO
{
    public interface IPaging
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
namespace advanded_csharp_database
{
    public interface ITransfrom<out T>
    {
        T Transfrom();
    }
}

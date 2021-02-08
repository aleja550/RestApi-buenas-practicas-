namespace RestApi.Entities
{
    public class Tenedor
    {
        public int Id { get; set; }
        public string NombreTenedor { get; set; }

        public Tenedor(int id, string nombreTenedor)
        {
            Id = id;
            NombreTenedor = nombreTenedor;
        }
    }
}

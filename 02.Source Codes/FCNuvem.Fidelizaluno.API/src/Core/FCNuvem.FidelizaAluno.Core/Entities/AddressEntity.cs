namespace FCNuvem.FidelizaAluno.Core.Entities
{

    public class AddressEntity : EntityBase
    {
        public AddressEntity(int id)
            : base(id)
        { }

        public string Cep { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Region { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

    }
}
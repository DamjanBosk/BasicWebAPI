namespace BasicWebAPI.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public int CountryId { get; set; }
    }
}

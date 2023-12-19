namespace BasicWebAPI.Dtos
{
    public class CreateUpdateContactRequest
    {
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public int CountryId { get; set; }
    }
}

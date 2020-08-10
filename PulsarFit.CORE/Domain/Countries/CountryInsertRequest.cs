namespace PulsarFit.CORE.Domain
{
    public class CountryInsertRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? CurrencyId { get; set; }
    }
}

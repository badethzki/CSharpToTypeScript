public class Invalid_WithNonPublicModifiers
{
    public string Name { get; set; }
    protected int Age { get; set; }
    private string Gender { get; set; }
    public long? DriverLicenceNumber { get; set; }
    internal List<Address> Addresses { get; set; }
    internal class Address
    {
        public int StreetNumber { get; set; }
        protected string StreetName { get; set; }
        public string Suburb { get; set; }
        public int PostCode { get; set; }
    }
}
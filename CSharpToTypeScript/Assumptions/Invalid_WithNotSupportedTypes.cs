public class Invalid_WithNotSupportedTypes
{
    public string Name { get; set; }
    public int Age { get; set; }
    public float Gender { get; set; }
    public long? DriverLicenceNumber { get; set; }
    public List<Address> Addresses { get; set; }
    public class Address
    {
        public decimal StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public double PostCode { get; set; }
    }
}
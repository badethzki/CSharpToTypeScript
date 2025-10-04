public class Valid_MultipleOneLevel
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public long? DriverLicenceNumber { get; set; }
    public List<Address1> Addresses { get; set; }
    public class Address1
    {
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public int PostCode { get; set; }
    }   
    public class Address2
    {
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public int PostCode { get; set; }
    }
}
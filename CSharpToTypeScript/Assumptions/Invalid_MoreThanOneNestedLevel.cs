public class Invalid_MoreThanOneNestedLevel
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
        public class Address2
        {
            public int StreetNumber2 { get; set; }
            public string StreetName2 { get; set; }
            public string Suburb2 { get; set; }
            public class Address3
            {
                public int StreetNumber3 { get; set; }
                public string StreetName3 { get; set; }
                public class Address4
                {
                    public int StreetNumber4 { get; set; }
                    public string StreetName4 { get; set; }
                }
                public class Address5
                {
                    public int StreetNumber5 { get; set; }
                    public string StreetName5 { get; set; }
                    public class Address6
                    {
                        public int StreetNumber6 { get; set; }
                    }
                }
            }
        }
        public class Address7
        {
            public int StreetNumber7 { get; set; }
            public string StreetName7 { get; set; }
        }
    }
}
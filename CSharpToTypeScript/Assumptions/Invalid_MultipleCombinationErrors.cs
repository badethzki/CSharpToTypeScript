public class Invalid_MultipleCombinationErrors
{
    public decimal Name { get; set; }
    public class Address1
    {
        public int StreetNumber1 { get; set; }
        internal class Address2
        {
            internal float StreetNumber2 { get; set; }
        }

        public int InvalidPosition1 { get; set; }
        public int InvalidPosition2 { get; set; }

        private class Address3
        {
            public int StreetNumber3 { get; set; }
        }

        public int InvalidPosition3 { get; set; }
    }
    private class Address4
    {
        public int StreetNumber4 { get; set; }
        public class Address5
        {
            private decimal StreetNumber5 { get; set; }

            private class Address6
            {
                public int StreetNumber6 { get; set; }
                public class Address7
                {
                    protected int StreetNumber7 { get; set; }
                }

                public int InvalidPosition4 { get; set; }
            }
        }
    }
}
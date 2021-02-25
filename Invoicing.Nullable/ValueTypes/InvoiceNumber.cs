namespace Invoicing
{
    public record InvoiceNumber
    {
        public string Value { get;}

        private InvoiceNumber(string number)
        {
            Value = number;
        }

        public static InvoiceNumber? Parse(string value)
        {
            if(!string.IsNullOrWhiteSpace(value) && value.Length == 8)
            {
                return new InvoiceNumber(value);
            }
            else
            {
                return null;
            }
        }

        public static readonly InvoiceNumber Default = new InvoiceNumber("TM000000");
    }
}

using LanguageExt;
using static LanguageExt.Prelude;

namespace Invoicing.ValueTypes
{
    public record InvoiceNumber
    {
        public string Value { get;}

        private InvoiceNumber(string number)
        {
            Value = number;
        }

        public static Option<InvoiceNumber> Parse(string value)
        {
            if(!string.IsNullOrWhiteSpace(value) && value.Length == 8)
            {
                return new InvoiceNumber(value);
            }
            else
            {
                return None;
            }
        }

        public static readonly InvoiceNumber Default = new InvoiceNumber("TM000000");
    }
}

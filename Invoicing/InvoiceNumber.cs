using LanguageExt;
using static LanguageExt.Prelude;

namespace Invoicing
{
    public class InvoiceNumber
    {
        public string Value { get;}

        private InvoiceNumber(string number)
        {
            Value = number;
        }

        public static Option<InvoiceNumber> Pare(string value)
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
    }
}

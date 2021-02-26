using LanguageExt;
using static LanguageExt.Prelude;

namespace Invoicing.ValueTypes
{
    public record PaymentReference
    {
        public string Value { get; }

        private PaymentReference(string value)
        {
            Value = value;
        }

        public static Option<PaymentReference> Parse(string value)
        {
            if(value.Length>=6 && value.Length <= 8)
            {
                return new PaymentReference(value);
            }
            else
            {
                return None;
            }
        }

        public static readonly PaymentReference Default = new PaymentReference("00-000");
    }
}

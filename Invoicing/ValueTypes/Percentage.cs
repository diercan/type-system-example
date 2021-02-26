using LanguageExt;
using static LanguageExt.Prelude;

namespace Invoicing.ValueTypes
{
    public record Percentage
    {
        public decimal Value { get; }

        private Percentage(decimal percentage)
        {
            Value = percentage;
        }

        public static Option<Percentage> Parse(decimal value)
        {
            if(value>=0 && value <= 100)
            {
                return new Percentage(value);
            }
            else
            {
                return None;
            }
        }

        public static readonly Percentage Default = new Percentage(0);
    }
}

using LanguageExt;
using static LanguageExt.Prelude;

namespace Invoicing.ValueTypes
{
    public record MoneyAmount
    {
        public decimal Value { get;}

        private MoneyAmount(decimal value)
        {
            Value = value;
        }

        public static Option<MoneyAmount> Parse(decimal value) => new MoneyAmount(value);

        public static readonly MoneyAmount Default = new MoneyAmount(0);
    }
}

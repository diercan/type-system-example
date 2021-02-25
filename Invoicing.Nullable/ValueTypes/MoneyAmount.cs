using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing.Nullable
{
    public record MoneyAmount
    {
        public decimal Value { get;}

        private MoneyAmount(decimal value)
        {
            Value = value;
        }

        public static MoneyAmount? Parse(decimal value) => new MoneyAmount(value);

        public static readonly MoneyAmount Default = new MoneyAmount(0);
    }
}

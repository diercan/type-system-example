using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing.Nullable
{
    public record PaymentReference
    {
        public string Value { get; }

        private PaymentReference(string value)
        {
            Value = value;
        }

        public static PaymentReference? Parse(string value)
        {
            if(value.Length>=6 && value.Length <= 8)
            {
                return new PaymentReference(value);
            }
            else
            {
                return null;
            }
        }

        public static readonly PaymentReference Default = new PaymentReference("00-000");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing.Nullable
{
    public record EmailReference
    {
        public string Value { get; }

        private EmailReference(string value)
        {
            Value = value;
        }

        public static EmailReference? Parse(string value)
        {
            if(value.Length>=8 && value.Length <= 10)
            {
                return new EmailReference(value);
            }
            else
            {
                return null;
            }
        }

        public static readonly EmailReference Default = new EmailReference("0000-000-0");
    }
}

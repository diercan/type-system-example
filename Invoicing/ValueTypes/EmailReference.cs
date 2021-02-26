using LanguageExt;
using static LanguageExt.Prelude;

namespace Invoicing.ValueTypes
{
    public record EmailReference
    {
        public string Value { get; }

        private EmailReference(string value)
        {
            Value = value;
        }

        public static Option<EmailReference> Parse(string value)
        {
            if(value.Length>=8 && value.Length <= 10)
            {
                return new EmailReference(value);
            }
            else
            {
                return None;
            }
        }

        public static readonly EmailReference Default = new EmailReference("0000-000-0");
    }
}

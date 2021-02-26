using Invoicing.ValueTypes;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing.Servicies
{
    public class EmailSender
    {
        public TryAsync<EmailReference> SendEmail(string address, string content, string body)
        => async () =>
        {
            return EmailReference.Default;
        };
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Invoicing.Nullable.Invoice;

namespace Invoicing.Nullable.Servicies
{
    public class InvoiceSenderService
    {
        public SentInvoice SendInvoice(ValidatedInvoice invoice)
        {
            Console.WriteLine($"Invoice {invoice.Invoice.Number} was paid.");
            var emailRef = EmailReference.Default;
            return new SentInvoice(invoice.Invoice, emailRef);
        }
    }
}

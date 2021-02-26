using Invoicing.Nullable.ValueTypes;
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
        public IInvoice Send(IInvoice invoice) =>
            invoice.Match(
                    whenUnvalidatedInvoice: ui => new InvalidInvoice(ui.Invoice, "Cannot send an unvalidated invoice."),
                    whenInvalidInvoice: ii => new InvalidInvoice(ii.Invoice, $"Cannot send an invalid invoice. Invalid invoice reason: {ii.Reason}"),
                    whenValidatedInvoice: vi => SendInternal(vi.Invoice),
                    whenPaidInvoice: pi => SendInternal(pi.Invoice),
                    whenSentInvoice: si => SendInternal(si.Invoice)
                );

        private IInvoice SendInternal(InvoiceDto invoice)
        {
            Console.WriteLine($"Invoice {invoice.Number} was sent.");
            var emailRef = EmailReference.Default;
            return new SentInvoice(invoice, emailRef);
        }
    }
}

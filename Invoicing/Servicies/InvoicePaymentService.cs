using Invoicing.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Invoicing.Invoice;

namespace Invoicing.Servicies
{
    public class InvoicePaymentService
    {
        public IInvoice Pay(IInvoice invoice) => 
            invoice.Match(
                    whenUnvalidatedInvoice: ui => new InvalidInvoice(ui.Invoice, "Cannot pay an unvalidated invoice."),
                    whenInvalidInvoice: ii => new InvalidInvoice(ii.Invoice, $"Cannot pay an invalid invoice. Invalid invoice reason: {ii.Reason}"),
                    whenValidatedInvoice: vi => new InvalidInvoice(vi.Invoice, "Cnnot pay a validated invoice that has not been sent."),
                    whenPaidInvoice: pi => new InvalidInvoice(pi.Invoice, "Cannot pay an already paid invoice"),
                    whenSentInvoice: PayInternal
                );

        private IInvoice PayInternal(SentInvoice invoice)
        {
            Console.WriteLine($"Invoice {invoice.Invoice.Number} was paid.");
            var paymentRef = PaymentReference.Default;
            return new PaidInvoice(invoice.Invoice, paymentRef);
        }
    }
}

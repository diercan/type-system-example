using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Invoicing.Invoice;

namespace Invoicing.Servicies
{
    public class InvoiceValidatorService
    {
        public IInvoice Validate(IInvoice invoice) =>
           invoice.Match(
                   whenInvalidInvoice: ii => new InvalidInvoice(ii.Invoice, $"Cannot validate an invalid invoice. Invalid invoice reason: {ii.Reason}"),
                   whenUnvalidatedInvoice: ui => ValidateInternal(ui.Invoice),
                   whenValidatedInvoice: vi => ValidateInternal(vi.Invoice),
                   whenPaidInvoice: pi => ValidateInternal(pi.Invoice),
                   whenSentInvoice: si => ValidateInternal(si.Invoice)
               );

        private IInvoice ValidateInternal(InvoiceDto invoice)
        {
            Console.WriteLine($"Invoice {invoice.Number} was validated.");
            return new ValidatedInvoice(invoice);
        }
    }
}

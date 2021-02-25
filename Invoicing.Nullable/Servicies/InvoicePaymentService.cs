using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Invoicing.Nullable.Invoice;

namespace Invoicing.Nullable.Servicies
{
    public class InvoicePaymentService
    {
        public PaidInvoice PayInvoice(SentInvoice invoice)
        {
            Console.WriteLine($"Invoice {invoice.Invoice.Number} was paid.");
            var paymentRef = PaymentReference.Default;
            return new PaidInvoice(invoice.Invoice, paymentRef);
        }
    }
}

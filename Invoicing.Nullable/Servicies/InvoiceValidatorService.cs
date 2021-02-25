using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Invoicing.Nullable.Invoice;

namespace Invoicing.Nullable.Servicies
{
    public class InvoiceValidatorService
    {
        public ValidatedInvoice Validate(UnvalidatedInvoice invoice)
        {
            return new ValidatedInvoice(invoice.Invoice);
        }
    }
}

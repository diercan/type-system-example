using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing.Nullable
{
    [AsChoice]
    public static partial class Invoice
    {
        public interface IInvoice { }

        public class UnvalidatedInvoice : IInvoice
        {
            public InvoiceDto Invoice { get;}

            public UnvalidatedInvoice(InvoiceDto invoice)
            {
                Invoice = invoice;
            }
        }

        public class ValidatedInvoice : IInvoice
        {
            public InvoiceDto Invoice { get; }

            internal ValidatedInvoice(InvoiceDto invoice)
            {
                Invoice = invoice;
            }
        }

        public class InvalidInvoice : IInvoice
        {
            public InvoiceDto Invoice { get; }
            public string Reason { get;}

            internal InvalidInvoice(InvoiceDto invoice, string reason)
            {
                Invoice = invoice;
                Reason = reason;
            }
        }

        public class SentInvoice : IInvoice
        {
            public InvoiceDto Invoice { get; }
            public EmailReference EmailReference { get; }

            internal SentInvoice(InvoiceDto invoice, EmailReference emailReference)
            {
                Invoice = invoice;
                EmailReference = emailReference;
            }
        }

        public class PaidInvoice : IInvoice
        {
            public InvoiceDto Invoice { get; }
            public PaymentReference PaymentReference { get; }

            internal PaidInvoice(InvoiceDto invoice, PaymentReference paymentReference)
            {
                Invoice = invoice;
                PaymentReference = paymentReference;
            }
        }
    }
}

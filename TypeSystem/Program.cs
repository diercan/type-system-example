using Invoicing.Nullable;
using Invoicing.Nullable.Servicies;
using Invoicing.Nullable.ValueTypes;
using System;
using static Invoicing.Nullable.Invoice;

namespace TypeSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = InvoiceNumber.Parse("TM000001");
            var total = MoneyAmount.Parse(100);
            if (number != null && total !=null)
            {
                InvoiceDto inputInvoice = new() { Number = number, Total = total };
                IInvoice invoice = new UnvalidatedInvoice(inputInvoice);
                invoice = new InvoiceValidatorService().Validate(invoice);
                invoice = new InvoiceSenderService().Send(invoice);
                invoice = new InvoicePaymentService().Pay(invoice);

                var message = invoice.Match<string>(
                    whenUnvalidatedInvoice: ui => "Invoice was not validated",
                    whenInvalidInvoice: ii => $"Invalid invoice. Reason: {ii.Reason}",
                    whenValidatedInvoice: vi => "Valid invoice",
                    whenSentInvoice: si => "Sent invoice",
                    whenPaidInvoice: pi => "Paid invoice");

                Console.WriteLine(message);
            }
        }
    }
}

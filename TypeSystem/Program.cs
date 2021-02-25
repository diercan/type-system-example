using Invoicing;
using Invoicing.Nullable;
using Invoicing.Nullable.Servicies;
using System;
using static Invoicing.Nullable.Invoice;

namespace TypeSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = InvoiceNumber.Parse("TM000001");
            if (number != null)
            {
                var inputInvoice = new InvoiceDto() { Number = number };
                var unvalidatedInvoice = new UnvalidatedInvoice(inputInvoice);
                var validatedInvoice = new InvoiceValidatorService().Validate(unvalidatedInvoice);
                var sentInvoice = new InvoiceSenderService().SendInvoice(validatedInvoice);
                var paidInvoice = new InvoicePaymentService().PayInvoice(sentInvoice);
            }
            
            Console.WriteLine("Hello World!");
        }
    }
}

using Invoicing;
using Invoicing.Servicies;
using Invoicing.ValueTypes;
using LanguageExt;
using System;
using static Invoicing.Invoice;

namespace TypeSystem.LanguageExt
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = from number in InvoiceNumber.Parse("TM000001")
                         from total in MoneyAmount.Parse(100)
                         let inputInvoice = new UnvalidatedInvoice(new() { Number = number, Total = total })
                         let finalInvoice = ProcessInvoice(inputInvoice)
                         select finalInvoice.Match<string>(
                                      whenUnvalidatedInvoice: ui => "Invoice was not validated",
                                      whenInvalidInvoice: ii => $"Invalid invoice. Reason: {ii.Reason}",
                                      whenValidatedInvoice: vi => "Valid invoice",
                                      whenSentInvoice: si => "Sent invoice",
                                      whenPaidInvoice: pi => "Paid invoice"); 


            result.Match(
                    Some: msg => Console.WriteLine(msg),
                    None: ()=>Console.WriteLine("Invlaid input")
                );
        }

        private static IInvoice ProcessInvoice(UnvalidatedInvoice input)
        {
                        var invoice = new InvoiceValidatorService().Validate(input);
                        invoice = new InvoiceSenderService().SendAsync(invoice).Result;
                        invoice = new InvoicePaymentService().Pay(invoice);
                        return invoice;   
        }
    }
}

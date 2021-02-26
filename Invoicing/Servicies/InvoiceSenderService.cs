using Invoicing.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Invoicing.Invoice;

namespace Invoicing.Servicies
{
    public class InvoiceSenderService
    {
        private EmailSender _emailSender;
        private Repository _repository;

        public InvoiceSenderService()
        {
            _emailSender = new EmailSender();
            _repository = new Repository();
        }

        public Task<IInvoice> SendAsync(IInvoice invoice) =>
            invoice.Match<Task<IInvoice>>(
                    whenUnvalidatedInvoice: ui => Task.FromResult((IInvoice)new InvalidInvoice(ui.Invoice, "Cannot send an unvalidated invoice.")),
                    whenInvalidInvoice: ii => Task.FromResult((IInvoice)new InvalidInvoice(ii.Invoice, $"Cannot send an invalid invoice. Invalid invoice reason: {ii.Reason}")),
                    whenValidatedInvoice: vi => SendInternalAsync(vi.Invoice),
                    whenPaidInvoice: pi => SendInternalAsync(pi.Invoice),
                    whenSentInvoice: si => SendInternalAsync(si.Invoice)
                );

        private Task<IInvoice> SendInternalAsync(InvoiceDto invoice)
        {
            var result = from emailRef in _emailSender.SendEmail(string.Empty, string.Empty, string.Empty)
                         let sentInvoice = new SentInvoice(invoice, emailRef)
                         from savedInvoice in _repository.SaveInvoice(sentInvoice)
                         select savedInvoice;

            Console.WriteLine($"Invoice {invoice.Number} was sent.");

            return result.Match(
                    Succ: inv => inv,
                    Fail: ex => new InvalidInvoice(invoice, ex.ToString())
                );
        }
    }
}

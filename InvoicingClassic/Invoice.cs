using System;

namespace InvoicingClassic
{
    public class Invoice
    {
        public string Number { get; set; } //What string is a valid invoice number?

        public DateTime Date { get; set; }

        public Customer Customer { get; set; }

        public InvoiceItem[] Details { get; set; }

        public decimal Total { get; set; } // How can I enforce that total always matched the line total

        public bool IsSent { get; set; } // What is the business logic behind this field?

        public string EmailReference { get; set; } // When is this field relevant

        public bool IsPaid { get; set; } // What is the business logic behind this field?

        public string PaymentReference { get; set; } // When is this field relevant
    }
}

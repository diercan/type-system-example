namespace InvoicingClassic
{
    public class InvoiceItem
    {
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal DiscountPercentage { get; set; } // How should I mark discount as optionsl?
        public decimal VatPercentage { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
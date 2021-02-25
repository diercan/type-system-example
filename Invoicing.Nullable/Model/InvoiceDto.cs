using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing.Nullable
{
    public record InvoiceDto
    {
        public InvoiceNumber Number { get; init; } = InvoiceNumber.Default;
        public DateTime Date { get; init; }
        public CustomerDto Customer { get; init; } = new CustomerDto();
        public IReadOnlyCollection<InvoiceItemDto> Details { get; init; } = new InvoiceItemDto[0];
        public MoneyAmount Total { get; set; } = MoneyAmount.Default;
    }
}

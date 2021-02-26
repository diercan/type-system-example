using LanguageExt;
using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Invoicing.Invoice;

namespace Invoicing.Servicies
{
    public class Repository
    {
        public TryAsync<IInvoice> SaveInvoice(IInvoice invoice)
        => async () =>
        {
            return new Result<IInvoice>(invoice);
        };
    }
}

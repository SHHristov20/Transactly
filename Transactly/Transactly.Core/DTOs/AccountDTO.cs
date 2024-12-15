using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactly.Core.DTOs
{
    public class CreateAccountDTO
    {
        public int UserId { get; set; }
        public int CurrencyId { get; set; }
    }
}

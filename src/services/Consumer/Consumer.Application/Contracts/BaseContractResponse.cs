using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Application.Contracts
{
    public class BaseContractResponse
    {
        public string? Message { get; set; }

        public int StatusCode { get; set; }
    }
}

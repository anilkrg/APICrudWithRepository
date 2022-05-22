using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICrudWithRepository.Contracts.Response
{
    public class APIResponse
    {
        public int Status { get; set; }
        public bool Ok { get; set; }
        public dynamic Data { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tariff.ApplicationService.Dtos
{
    public class ItemResponse
    {
        public bool Success { get; set; }

        public string Error { get; set; }

        public int? ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

    }

    public class ItemDataResponse<T> : ItemResponse
    {
        public T Data { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperations.Model.StockModel
{
    public class GetStockRecordByIdResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public InsertStockRecordRequest data { get; set; }
    }

    public class GetStockRecordByNameResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<InsertStockRecordRequest> data { get; set; }
    }

}

using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperations.Model.StockModel
{
    public class GetAllStockRecordResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<InsertStockRecordRequest> data { get; set; }
    }

}

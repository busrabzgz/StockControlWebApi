using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperations.Model.StockModel
{
    public class DeleteStockRecordByIdRequest
    {
        [Required]
        public string Id { get; set; }
    }

    public class DeleteStockRecordByIdResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}

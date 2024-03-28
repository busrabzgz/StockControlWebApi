using CrudOperations.Entitiy;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperations.Model.StockModel
{

    public class InsertStockRecordRequest
    {
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public string Id { get; set; }

        public string ProductCode { get; set; }


        public string ProductName { get; set; }

        public string Category { get; set; }

        public int StockQuantity { get; set; }

        public double UnitPrice { get; set; }


        public string Supplier { get; set; }

        public string CreatedDate { get; set; }

        public string UpdatedDate { get; set; }
    }


    public class InsertStockRecordResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }




}

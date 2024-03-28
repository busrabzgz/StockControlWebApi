using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using CrudOperations.Model.StockModel;

namespace CrudOperations.Entitiy
{
    public class Stock
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("ProductCode")]
        [Required]
        public string ProductCode { get; set; }

        [BsonElement("ProductName")]
        [Required]
        public string ProductName { get; set; }

        [BsonElement("Category")]
        [Required]
        public string Category { get; set; }

        [BsonElement("StockQuantity")]
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity must be a non-negative number.")]
        public int StockQuantity { get; set; }

        [BsonElement("UnitPrice")]
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Unit price must be a non-negative number.")]
        public double UnitPrice { get; set; }

        [BsonElement("Supplier")]
        public string Supplier { get; set; }

        public string CreatedDate { get; set; }

        public string UpdatedDate { get; set; }


        public List<InsertStockRecordRequest> Requests { get; set; } = new List<InsertStockRecordRequest>();


        public List<InsertStockRecordResponse> Responses { get; set; } = new List<InsertStockRecordResponse>();
    }





}

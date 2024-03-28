using CrudOperations.Model.StockModel;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperations.DataAccessLayer
{
    public class StockCrudOperationDL : IStockCrudOperationDL
    {
        private readonly IConfiguration _configuration;
        private readonly MongoClient _mongoConnection;
        private readonly IMongoCollection<InsertStockRecordRequest> _stocksCollection;
        public StockCrudOperationDL(IConfiguration configuration)
        {
            _configuration = configuration;
            _mongoConnection = new MongoClient(_configuration["StockControlDatabase:ConnectionString"]);
            var MongoDataBase = _mongoConnection.GetDatabase(_configuration["StockControlDatabase:DatabaseName"]);
            _stocksCollection = MongoDataBase.GetCollection<InsertStockRecordRequest>(_configuration["StockControlDatabase:StockControlCollectionName"]);
        }

        public async Task<InsertStockRecordResponse> InsertStockRecord(InsertStockRecordRequest request)
        {
            InsertStockRecordResponse response = new InsertStockRecordResponse();
            response.IsSuccess = true;
            response.Message = "Stock Successfully Insert";

            try
            {
                request.CreatedDate = DateTime.Now.ToString(); 
                request.UpdatedDate = string.Empty;
                await _stocksCollection.InsertOneAsync(request);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }

        public async Task<GetAllStockRecordResponse> GetAllStockRecord()
        {
            GetAllStockRecordResponse response = new GetAllStockRecordResponse();
            response.IsSuccess = true;
            response.Message = "Stock Fetch Successfully";

            try
            {
                response.data = new List<InsertStockRecordRequest>();
                response.data = await _stocksCollection.Find(x => true).ToListAsync();
                if (response.data.Count == 0)
                {
                    response.Message = "No Stock Found";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }

        public async Task<GetStockRecordByIdResponse> GetStockRecordById(string ID)
        {
            GetStockRecordByIdResponse response = new GetStockRecordByIdResponse();
            response.IsSuccess = true;
            response.Message = "Fetch Stock Successfully by ID";

            try
            {
                response.data = await _stocksCollection.Find(x => (x.Id == ID)).FirstOrDefaultAsync();
                if(response.data == null)
                {
                    response.Message = "No Stock Found";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }

        public async Task<GetStockRecordByNameResponse> GetStockRecordByName(string Name)
        {
            GetStockRecordByNameResponse response = new GetStockRecordByNameResponse();
            response.IsSuccess = true;
            response.Message = "Fetch Stock Successfully By ProductName";

            try
            {
                response.data = new List<InsertStockRecordRequest>();
                response.data = await _stocksCollection.Find(x => (x.ProductName == Name) ).ToListAsync();
                if (response.data.Count==0)
                {
                    response.Message = "No Stock Found";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }

        public async Task<UpdateRecordByIdResponse> UpdateStockRecordById(InsertStockRecordRequest request)
        {
            UpdateRecordByIdResponse response = new UpdateRecordByIdResponse();
            response.IsSuccess = true;
            response.Message = "Update Stock Successfully By Id";

            try
            {
                GetStockRecordByIdResponse GetResponse = await GetStockRecordById(request.Id);
                if (!GetResponse.IsSuccess)
                {
                    response.IsSuccess = false;
                    response.Message = GetResponse.Message;
                    return response;
                }

                request.CreatedDate = GetResponse.data.CreatedDate;
                request.UpdatedDate = DateTime.Now.ToString();

                var Result = await _stocksCollection.ReplaceOneAsync(x => x.Id == request.Id, request);
                if (!Result.IsAcknowledged)
                {
                    response.Message = "Input Id Not Found / Updation Not Occurs";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }

        public async Task<UpdateRecordByIdResponse> UpdateStockSalaryById(UpdateSalaryByIdRequest request)
        {
            UpdateRecordByIdResponse response = new UpdateRecordByIdResponse();
            response.IsSuccess = true;
            response.Message = "Update Stock's UnitPrice Successfully";

            try
            {
                var Filter = new BsonDocument()
                    .Add("UnitPrice", request.UnitPrice)
                    .Add("UpdatedDate", DateTime.Now.ToString());

                var updateDoc = new BsonDocument("$set", Filter);

                var Result = await _stocksCollection.UpdateOneAsync(x=>x.Id==request.Id, updateDoc);

            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }

        public async Task<DeleteStockRecordByIdResponse> DeleteStockRecordById(DeleteStockRecordByIdRequest request)
        {
            DeleteStockRecordByIdResponse response = new DeleteStockRecordByIdResponse();
            response.IsSuccess = true;
            response.Message = "Delete Stock Successfully By Id";

            try
            {

                var result = await _stocksCollection.DeleteOneAsync(x => x.Id == request.Id);
                if (!result.IsAcknowledged)
                {
                    response.IsSuccess = true;
                    response.Message = "Stock Not Found In Database For Deletion, Please Enter Valid Id";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }

        public async Task<DeleteAllStockRecordResponse> DeleteAllStockRecord()
        {
            DeleteAllStockRecordResponse response = new DeleteAllStockRecordResponse();
            response.IsSuccess = true;
            response.Message = "Clear All Stock Successfully";

            try
            {
                var Result = await _stocksCollection.DeleteManyAsync(x => true);
                if (!Result.IsAcknowledged)
                {
                    response.IsSuccess = false;
                    response.Message = "Something Went Wrong.";
                }
                else
                {
                    response.Message = Result.DeletedCount == 0 ? "Database Already Cleaned." : response.Message;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }

        
    }
}

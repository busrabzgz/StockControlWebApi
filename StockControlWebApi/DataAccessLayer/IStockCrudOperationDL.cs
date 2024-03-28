using CrudOperations.Model.StockModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperations.DataAccessLayer
{
    public interface IStockCrudOperationDL
    {
        public Task<InsertStockRecordResponse> InsertStockRecord(InsertStockRecordRequest request);

        public Task<GetAllStockRecordResponse> GetAllStockRecord();

        public Task<GetStockRecordByIdResponse> GetStockRecordById(string ID);

        public Task<GetStockRecordByNameResponse> GetStockRecordByName(string Name);

        public Task<UpdateRecordByIdResponse> UpdateStockRecordById(InsertStockRecordRequest request);

        public Task<UpdateRecordByIdResponse> UpdateStockSalaryById(UpdateUnitPrinceByIdRequest request);

        public Task<DeleteStockRecordByIdResponse> DeleteStockRecordById(DeleteStockRecordByIdRequest request);

        public Task< DeleteAllStockRecordResponse> DeleteAllStockRecord();
    }
}

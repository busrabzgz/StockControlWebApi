using CrudOperations.DataAccessLayer;
using CrudOperations.Model.StockModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperations.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class StockCrudController : ControllerBase
    {
        private readonly IStockCrudOperationDL _stockCrudOperationDL;
        public StockCrudController(IStockCrudOperationDL crudOperationDL)
        {
            _stockCrudOperationDL = crudOperationDL;
        }

        [HttpPost]
        public async Task<IActionResult> InsertStockRecord(InsertStockRecordRequest request)
        {
            InsertStockRecordResponse response = new InsertStockRecordResponse();
            try
            {
                 response = await _stockCrudOperationDL.InsertStockRecord(request);
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStockRecord()
        {
            GetAllStockRecordResponse response = new GetAllStockRecordResponse();
            try
            {
                response = await _stockCrudOperationDL.GetAllStockRecord();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetStockRecordById([FromQuery]string Id)
        {
            GetStockRecordByIdResponse response = new GetStockRecordByIdResponse();
            try
            {
                response = await _stockCrudOperationDL.GetStockRecordById(Id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetStockRecordByName([FromQuery] string Name)
        {
            GetStockRecordByNameResponse response = new GetStockRecordByNameResponse();
            try
            {
                response = await _stockCrudOperationDL.GetStockRecordByName(Name);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStockRecordById(InsertStockRecordRequest request)
        {
            UpdateRecordByIdResponse response = new UpdateRecordByIdResponse();
            try
            {
                response = await _stockCrudOperationDL.UpdateStockRecordById(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateStockSalaryById(UpdateSalaryByIdRequest request)
        {
            UpdateRecordByIdResponse response = new UpdateRecordByIdResponse();
            try
            {
                response = await _stockCrudOperationDL.UpdateStockSalaryById(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteStockRecordById(DeleteStockRecordByIdRequest request)
        {
            DeleteStockRecordByIdResponse response = new DeleteStockRecordByIdResponse();
            try
            {
                response = await _stockCrudOperationDL.DeleteStockRecordById(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllStockRecord()
        {
            DeleteAllStockRecordResponse response = new DeleteAllStockRecordResponse();
            try
            {
                response = await _stockCrudOperationDL.DeleteAllStockRecord();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }
    }
}

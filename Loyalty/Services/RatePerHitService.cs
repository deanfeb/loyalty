using Loyalty.Entities;
using Loyalty.Entities.Transaction;
using jQueryDataTable.DynamicLinq;

namespace Loyalty.Services
{
    public class RatePerHitService : Interfaces.Services.IRatePerHitService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RatePerHitService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ResponseBase<RatePerHit> Add(RatePerHit emp)
        {
            var response = new ResponseBase<RatePerHit>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                emp.CreatedBy = 1;
                emp.DateCreated = DateTime.Now;
                _unitOfWork.RatePerHits.Add(emp);
                _unitOfWork.Complete();
                response.Data = emp;
            }
            catch (Exception ex)
            {
                response.Success = SuccessType.Failed;
                response.Message = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message);
                //throw;
            }
            return response;
        }

        public ResponseBase<RatePerHit> Delete(int id)
        {
            var response = new ResponseBase<RatePerHit>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var RatePerHit = _unitOfWork.RatePerHits.GetById(id);
                RatePerHit.DeletedBy = 1; //FIELD
                RatePerHit.DateDeleted = DateTime.Now; //FIELD
                RatePerHit.isDeleted = true; //FIELD
                _unitOfWork.Complete();
                response.Data = RatePerHit;
            }
            catch (Exception ex)
            {
                response.Success = SuccessType.Failed;
                response.Message = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message);
                //throw;
            }
            return response;
        }

        public ResponseBase<RatePerHit> Get(int id)
        {
            var response = new ResponseBase<RatePerHit>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var unit = _unitOfWork.RatePerHits.GetById(id);
                response.Data = unit;
            }
            catch (Exception ex)
            {
                response.Success = SuccessType.Failed;
                response.Message = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message);
                //throw;
            }
            return response;
        }

        public ResponseBase<RatePerHit> Update(RatePerHit obj)
        {
            var response = new ResponseBase<RatePerHit>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var RatePerHit = _unitOfWork.RatePerHits.GetById(obj.Id);
                RatePerHit.ModifiedBy = 1;
                RatePerHit.DateModified = DateTime.Now;
                _unitOfWork.Complete();
                response.Data = RatePerHit;
            }
            catch (Exception ex)
            {
                response.Success = SuccessType.Failed;
                response.Message = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message);
                //throw;
            }
            return response;
        }

        public Result GetList(jQueryDataRequest param)
        {
            Result result = new Result();
            result.draw = param.draw;

            var data = _unitOfWork.RatePerHits.GetQueryable(param);
            result.data = data.Take(param.length).Skip(param.length * param.start);
            result.recordsTotal = data.Count();
            return result;

        }
    }
}

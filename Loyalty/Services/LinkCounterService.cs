using Loyalty.Entities;
using Loyalty.Entities.Transaction;
using jQueryDataTable.DynamicLinq;

namespace Loyalty.Services
{
    public class LinkCounterService : Interfaces.Services.ILinkCounterService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LinkCounterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ResponseBase<LinkCounter> Add(LinkCounter emp)
        {
            var response = new ResponseBase<LinkCounter>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                emp.CreatedBy = 1;
                emp.DateCreated = DateTime.Now;
                _unitOfWork.LinkCounters.Add(emp);
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

        public ResponseBase<LinkCounter> Delete(int id)
        {
            var response = new ResponseBase<LinkCounter>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var LinkCounter = _unitOfWork.LinkCounters.GetById(id);
                LinkCounter.DeletedBy = 1; //FIELD
                LinkCounter.DateDeleted = DateTime.Now; //FIELD
                LinkCounter.isDeleted = true; //FIELD
                _unitOfWork.Complete();
                response.Data = LinkCounter;
            }
            catch (Exception ex)
            {
                response.Success = SuccessType.Failed;
                response.Message = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message);
                //throw;
            }
            return response;
        }

        public ResponseBase<LinkCounter> Get(int id)
        {
            var response = new ResponseBase<LinkCounter>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var unit = _unitOfWork.LinkCounters.GetById(id);
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

        public ResponseBase<LinkCounter> Update(LinkCounter obj)
        {
            var response = new ResponseBase<LinkCounter>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var LinkCounter = _unitOfWork.LinkCounters.GetById(obj.Id);
                LinkCounter.ModifiedBy = 1;
                LinkCounter.DateModified = DateTime.Now;
                _unitOfWork.Complete();
                response.Data = LinkCounter;
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

            var data = _unitOfWork.LinkCounters.GetQueryable(param);
            result.data = data.Take(param.length).Skip(param.length * param.start);
            result.recordsTotal = data.Count();
            return result;

        }
    }
}

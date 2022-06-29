using Loyalty.Entities;
using Loyalty.Entities.Transaction;
using jQueryDataTable.DynamicLinq;

namespace Loyalty.Services
{
    public class KoordinatorService : Interfaces.Services.IKoordinatorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public KoordinatorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ResponseBase<Koordinator> Add(Koordinator emp)
        {
            var response = new ResponseBase<Koordinator>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                emp.CreatedBy = 1;
                emp.DateCreated = DateTime.Now;
                _unitOfWork.Koordinators.Add(emp);
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

        public ResponseBase<Koordinator> Delete(int id)
        {
            var response = new ResponseBase<Koordinator>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var Koordinator = _unitOfWork.Koordinators.GetById(id);
                Koordinator.DeletedBy = 1; //FIELD
                Koordinator.DateDeleted = DateTime.Now; //FIELD
                Koordinator.isDeleted = true; //FIELD
                _unitOfWork.Complete();
                response.Data = Koordinator;
            }
            catch (Exception ex)
            {
                response.Success = SuccessType.Failed;
                response.Message = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message);
                //throw;
            }
            return response;
        }

        public ResponseBase<Koordinator> Get(int id)
        {
            var response = new ResponseBase<Koordinator>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var unit = _unitOfWork.Koordinators.GetById(id);
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

        public ResponseBase<Koordinator> Update(Koordinator obj)
        {
            var response = new ResponseBase<Koordinator>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var Koordinator = _unitOfWork.Koordinators.GetById(obj.Id);
                Koordinator.ModifiedBy = 1;
                Koordinator.DateModified = DateTime.Now;
                _unitOfWork.Complete();
                response.Data = Koordinator;
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

            var data = _unitOfWork.Koordinators.GetQueryable(param);
            result.data = data.Take(param.length).Skip(param.length * param.start);
            result.recordsTotal = data.Count();
            return result;

        }
    }
}

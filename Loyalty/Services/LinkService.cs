using Loyalty.Entities;
using Loyalty.Entities.Transaction;
using jQueryDataTable.DynamicLinq;

namespace Loyalty.Services
{
    public class LinkService : Interfaces.Services.ILinkService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LinkService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ResponseBase<Link> Add(Link emp)
        {
            var response = new ResponseBase<Link>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                emp.CreatedBy = 1;
                emp.DateCreated = DateTime.Now;
                _unitOfWork.Links.Add(emp);
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

        public ResponseBase<Link> Delete(int id)
        {
            var response = new ResponseBase<Link>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var Link = _unitOfWork.Links.GetById(id);
                Link.DeletedBy = 1; //FIELD
                Link.DateDeleted = DateTime.Now; //FIELD
                Link.isDeleted = true; //FIELD
                _unitOfWork.Complete();
                response.Data = Link;
            }
            catch (Exception ex)
            {
                response.Success = SuccessType.Failed;
                response.Message = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message);
                //throw;
            }
            return response;
        }

        public ResponseBase<Link> Get(int id)
        {
            var response = new ResponseBase<Link>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var unit = _unitOfWork.Links.GetById(id);
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

        public ResponseBase<Link> Update(Link obj)
        {
            var response = new ResponseBase<Link>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var Link = _unitOfWork.Links.GetById(obj.Id);
                Link.ModifiedBy = 1;
                Link.DateModified = DateTime.Now;
                _unitOfWork.Complete();
                response.Data = Link;
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

            var data = _unitOfWork.Links.GetQueryable(param);
            result.data = data.Take(param.length).Skip(param.length * param.start);
            result.recordsTotal = data.Count();
            return result;

        }
    }
}

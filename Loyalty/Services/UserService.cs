using Loyalty.Entities;
using Loyalty.Entities.Master;
using jQueryDataTable.DynamicLinq;

namespace Loyalty.Services
{
    public class UserService : Interfaces.Services.IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ResponseBase<User> Add(User emp)
        {
            var response = new ResponseBase<User>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                emp.CreatedBy = 1;
                emp.DateCreated = DateTime.Now;
                emp.ModifiedBy = null;
                emp.DateModified = null;
                _unitOfWork.Users.Add(emp);
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

        public ResponseBase<User> Delete(int id)
        {
            var response = new ResponseBase<User>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var User = _unitOfWork.Users.GetById(id);
                User.DeletedBy = 1; //FIELD
                User.DateDeleted = DateTime.Now; //FIELD
                User.IsDeleted = true; //FIELD
                _unitOfWork.Complete();
                response.Data = User;
            }
            catch (Exception ex)
            {
                response.Success = SuccessType.Failed;
                response.Message = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message);
                //throw;
            }
            return response;
        }

        public ResponseBase<User> Get(int id)
        {
            var response = new ResponseBase<User>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var unit = _unitOfWork.Users.GetById(id);
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

        public ResponseBase<User> Update(User obj)
        {
            var response = new ResponseBase<User>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var User = _unitOfWork.Users.GetById(obj.UserId);
                User.ModifiedBy = 1;
                User.DateModified = DateTime.Now;
                _unitOfWork.Complete();
                response.Data = User;
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

            var data = _unitOfWork.Users.GetQueryable(param);
            result.data = data.Take(param.length).Skip(param.length * param.start);
            result.recordsTotal = data.Count();
            return result;

        }
    }
}

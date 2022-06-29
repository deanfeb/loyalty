using Loyalty.Entities;
using Loyalty.Entities.Master;
using jQueryDataTable.DynamicLinq;

namespace Loyalty.Services
{
    public class RoleService : Interfaces.Services.IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ResponseBase<Role> Add(Role emp)
        {
            var response = new ResponseBase<Role>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                emp.CreatedBy = 1;
                emp.DateCreated = DateTime.Now;
                emp.ModifiedBy = null;
                emp.DateModified = null;
                _unitOfWork.Roles.Add(emp);
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

        public ResponseBase<Role> Delete(int id)
        {
            var response = new ResponseBase<Role>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var Role = _unitOfWork.Roles.GetById(id);
                Role.DeletedBy = 1; //FIELD
                Role.DateDeleted = DateTime.Now; //FIELD
                Role.IsDeleted = true; //FIELD
                _unitOfWork.Complete();
                response.Data = Role;
            }
            catch (Exception ex)
            {
                response.Success = SuccessType.Failed;
                response.Message = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message);
                //throw;
            }
            return response;
        }

        public ResponseBase<Role> Get(int id)
        {
            var response = new ResponseBase<Role>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var unit = _unitOfWork.Roles.GetById(id);
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

        public ResponseBase<Role> Update(Role obj)
        {
            var response = new ResponseBase<Role>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var Role = _unitOfWork.Roles.GetById(obj.RoleId);
                Role.ModifiedBy = 1;
                Role.DateModified = DateTime.Now;
                _unitOfWork.Complete();
                response.Data = Role;
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

            var data = _unitOfWork.Roles.GetQueryable(param);
            result.data = data.Take(param.length).Skip(param.length * param.start);
            result.recordsTotal = data.Count();
            return result;

        }
    }
}

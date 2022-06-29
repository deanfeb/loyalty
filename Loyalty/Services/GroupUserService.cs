using Loyalty.Entities;
using Loyalty.Entities.Master;
using jQueryDataTable.DynamicLinq;

namespace Loyalty.Services
{
    public class GroupUserService : Interfaces.Services.IGroupUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GroupUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ResponseBase<GroupUser> Add(GroupUser emp)
        {
            var response = new ResponseBase<GroupUser>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                emp.CreatedBy = 1;
                emp.DateCreated = DateTime.Now;
                emp.ModifiedBy = null;
                emp.DateModified = null;
                _unitOfWork.GroupUsers.Add(emp);
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

        public ResponseBase<GroupUser> Delete(int id)
        {
            var response = new ResponseBase<GroupUser>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var GroupUser = _unitOfWork.GroupUsers.GetById(id);
                GroupUser.DeletedBy = 1; //FIELD
                GroupUser.DateDeleted = DateTime.Now; //FIELD
                GroupUser.isDeleted = true; //FIELD
                _unitOfWork.Complete();
                response.Data = GroupUser;
            }
            catch (Exception ex)
            {
                response.Success = SuccessType.Failed;
                response.Message = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message);
                //throw;
            }
            return response;
        }

        public ResponseBase<GroupUser> Get(int id)
        {
            var response = new ResponseBase<GroupUser>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var unit = _unitOfWork.GroupUsers.GetById(id);
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

        public ResponseBase<GroupUser> Update(GroupUser obj)
        {
            var response = new ResponseBase<GroupUser>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var GroupUser = _unitOfWork.GroupUsers.GetById(obj.Id);
                GroupUser.UserId = obj.UserId;
                GroupUser.GroupID = obj.GroupID;
                GroupUser.Status = obj.Status;
                GroupUser.ModifiedBy = 1;
                GroupUser.DateModified = DateTime.Now;
                _unitOfWork.Complete();
                response.Data = GroupUser;
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

            var data = _unitOfWork.GroupUsers.GetQueryable(param);
            result.data = data.Take(param.length).Skip(param.length * param.start);
            result.recordsTotal = data.Count();
            return result;

        }
    }
}

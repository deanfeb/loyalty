using Loyalty.Entities;
using Loyalty.Entities.Master;
using jQueryDataTable.DynamicLinq;
using Loyalty.Entities.Transaction;

namespace Loyalty.Services
{
    public class GroupService : Interfaces.Services.IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GroupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ResponseBase<Group> Add(Group emp)
        {
            var response = new ResponseBase<Group>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                emp.CreatedBy = 1;
                emp.DateCreated = DateTime.Now;
                emp.ModifiedBy = null;
                emp.DateModified = null;
                _unitOfWork.Groups.Add(emp);
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

        public ResponseBase<Group> Delete(int id)
        {
            var response = new ResponseBase<Group>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var Group = _unitOfWork.Groups.GetById(id);
                Group.DeletedBy = 1; //FIELD
                Group.DateDeleted = DateTime.Now; //FIELD
                Group.isDeleted = true; //FIELD
                _unitOfWork.Complete();
                response.Data = Group;
            }
            catch (Exception ex)
            {
                response.Success = SuccessType.Failed;
                response.Message = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message);
                //throw;
            }
            return response;
        }

        public ResponseBase<Group> Get(int id)
        {
            var response = new ResponseBase<Group>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var unit = _unitOfWork.Groups.GetById(id);
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

        public ResponseBase<Group> Update(Group obj)
        {
            var response = new ResponseBase<Group>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var Group = _unitOfWork.Groups.GetById(obj.Id);
                Group.Code = obj.Code;
                Group.Name = obj.Name;
                Group.Status = obj.Status;
                Group.ModifiedBy = 1;
                Group.DateModified = DateTime.Now;
                _unitOfWork.Complete();
                response.Data = Group;
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

            var data = _unitOfWork.Groups.GetQueryable(param);
            result.data = data.Take(param.length).Skip(param.length * param.start);
            result.recordsTotal = data.Count();
            return result;

        }
    }
}

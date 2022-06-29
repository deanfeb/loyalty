using Loyalty.Entities;
using Loyalty.Entities.Master;
using jQueryDataTable.DynamicLinq;

namespace Loyalty.Services
{
    public class GroupMenuService : Interfaces.Services.IGroupMenuService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GroupMenuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ResponseBase<GroupMenu> Add(GroupMenu emp)
        {
            var response = new ResponseBase<GroupMenu>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                emp.Status = true;
                emp.CreatedBy = 1;
                emp.DateCreated = DateTime.Now;
                emp.ModifiedBy = null;
                emp.DateModified = null;
                _unitOfWork.GroupMenus.Add(emp);
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

        public ResponseBase<GroupMenu> Delete(int id)
        {
            var response = new ResponseBase<GroupMenu>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var GroupMenu = _unitOfWork.GroupMenus.GetById(id);
                GroupMenu.DeletedBy = 1; //FIELD
                GroupMenu.DateDeleted = DateTime.Now; //FIELD
                GroupMenu.isDeleted = true; //FIELD
                _unitOfWork.Complete();
                response.Data = GroupMenu;
            }
            catch (Exception ex)
            {
                response.Success = SuccessType.Failed;
                response.Message = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message);
                //throw;
            }
            return response;
        }

        public ResponseBase<GroupMenu> Get(int id)
        {
            var response = new ResponseBase<GroupMenu>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var unit = _unitOfWork.GroupMenus.GetById(id);
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

        public ResponseBase<GroupMenu> Update(GroupMenu obj)
        {
            var response = new ResponseBase<GroupMenu>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var GroupMenu = _unitOfWork.GroupMenus.GetById(obj.Id);
                GroupMenu.MenuID = obj.MenuID;
                GroupMenu.GroupID = obj.GroupID;
                GroupMenu.ModifiedBy = 1; //USER ID
                GroupMenu.DateModified = DateTime.Now;
                GroupMenu.Status = obj.Status;
                _unitOfWork.Complete();
                response.Data = GroupMenu;
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

            var data = _unitOfWork.GroupMenus.GetQueryable(param);
            result.data = data.Take(param.length).Skip(param.length * param.start);
            result.recordsTotal = data.Count();
            return result;

        }
    }
}

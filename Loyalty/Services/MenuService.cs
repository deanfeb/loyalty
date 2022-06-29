using Loyalty.Entities;
using Loyalty.Entities.Master;
using jQueryDataTable.DynamicLinq;

namespace Loyalty.Services
{
    public class MenuService : Interfaces.Services.IMenuService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MenuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ResponseBase<Menu> Add(Menu emp)
        {
            var response = new ResponseBase<Menu>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                emp.CreatedBy = 1;
                emp.DateCreated = DateTime.Now;
                emp.ModifiedBy = null;
                emp.DateModified = null;
                _unitOfWork.Menus.Add(emp);
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

        public ResponseBase<Menu> Delete(int id)
        {
            var response = new ResponseBase<Menu>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var Menu = _unitOfWork.Menus.GetById(id);
                Menu.DeletedBy = 1; //FIELD
                Menu.DateDeleted = DateTime.Now; //FIELD
                Menu.isDeleted = true; //FIELD
                _unitOfWork.Complete();
                response.Data = Menu;
            }
            catch (Exception ex)
            {
                response.Success = SuccessType.Failed;
                response.Message = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message);
                //throw;
            }
            return response;
        }

        public ResponseBase<Menu> Get(int id)
        {
            var response = new ResponseBase<Menu>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var unit = _unitOfWork.Menus.GetById(id);
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

        public ResponseBase<Menu> Update(Menu obj)
        {
            var response = new ResponseBase<Menu>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var Menu = _unitOfWork.Menus.GetById(obj.MenuID);
                Menu.UrlAddress = obj.UrlAddress;
                Menu.Icon = obj.Icon;
                Menu.Title = obj.Title;
                Menu.Parent = obj.Parent;
                Menu.Level = obj.Level;
                Menu.Order = obj.Order;
                Menu.Status = obj.Status;
                Menu.Feature = obj.Feature;
                Menu.ModifiedBy = 1;
                Menu.DateModified = DateTime.Now;
                _unitOfWork.Complete();
                response.Data = Menu;
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

            var data = _unitOfWork.Menus.GetQueryable(param);
            result.data = data.Take(param.length).Skip(param.length * param.start);
            result.recordsTotal = data.Count();
            return result;

        }
    }
}

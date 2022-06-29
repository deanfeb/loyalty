using Loyalty.Entities;
using Loyalty.Entities.Transaction;
using jQueryDataTable.DynamicLinq;

namespace Loyalty.Services
{
    public class ProjectService : Interfaces.Services.IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ResponseBase<Project> Add(Project emp)
        {
            var response = new ResponseBase<Project>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                emp.CreatedBy = 1;
                emp.DateCreated = DateTime.Now;
                _unitOfWork.Projects.Add(emp);
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

        public ResponseBase<Project> Delete(int id)
        {
            var response = new ResponseBase<Project>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var Project = _unitOfWork.Projects.GetById(id);
                Project.DeletedBy = 1; //FIELD
                Project.DateDeleted = DateTime.Now; //FIELD
                Project.isDeleted = true; //FIELD
                _unitOfWork.Complete();
                response.Data = Project;
            }
            catch (Exception ex)
            {
                response.Success = SuccessType.Failed;
                response.Message = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message);
                //throw;
            }
            return response;
        }

        public ResponseBase<Project> Get(int id)
        {
            var response = new ResponseBase<Project>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var unit = _unitOfWork.Projects.GetById(id);
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

        public ResponseBase<Project> Update(Project obj)
        {
            var response = new ResponseBase<Project>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var Project = _unitOfWork.Projects.GetById(obj.Id);
                Project.ModifiedBy = 1;
                Project.DateModified = DateTime.Now;
                _unitOfWork.Complete();
                response.Data = Project;
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

            var data = _unitOfWork.Projects.GetQueryable(param);
            result.data = data.Take(param.length).Skip(param.length * param.start);
            result.recordsTotal = data.Count();
            return result;

        }
    }
}

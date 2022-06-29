using Loyalty.Entities;
using Loyalty.Entities.Transaction;
using jQueryDataTable.DynamicLinq;

namespace Loyalty.Services
{
    public class MemberService : Interfaces.Services.IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ResponseBase<Member> Add(Member emp)
        {
            var response = new ResponseBase<Member>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                emp.CreatedBy = 1;
                emp.DateCreated = DateTime.Now;
                _unitOfWork.Members.Add(emp);
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

        public ResponseBase<Member> Delete(int id)
        {
            var response = new ResponseBase<Member>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var Member = _unitOfWork.Members.GetById(id);
                Member.DeletedBy = 1; //FIELD
                Member.DateDeleted = DateTime.Now; //FIELD
                Member.isDeleted = true; //FIELD
                _unitOfWork.Complete();
                response.Data = Member;
            }
            catch (Exception ex)
            {
                response.Success = SuccessType.Failed;
                response.Message = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message);
                //throw;
            }
            return response;
        }

        public ResponseBase<Member> Get(int id)
        {
            var response = new ResponseBase<Member>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var unit = _unitOfWork.Members.GetById(id);
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

        public ResponseBase<Member> Update(Member obj)
        {
            var response = new ResponseBase<Member>() { Success = SuccessType.Success, Message = "Success" };

            try
            {
                var Member = _unitOfWork.Members.GetById(obj.Id);
                Member.ModifiedBy = 1;
                Member.DateModified = DateTime.Now;
                _unitOfWork.Complete();
                response.Data = Member;
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

            var data = _unitOfWork.Members.GetQueryable(param);
            result.data = data.Take(param.length).Skip(param.length * param.start);
            result.recordsTotal = data.Count();
            return result;

        }
    }
}

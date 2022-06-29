using Loyalty.Entities;

namespace Loyalty.Interfaces.Services
{
    public interface IBaseService<T>
    {
        ResponseBase<T> Add(T obj);
        ResponseBase<T> Get(int id);

        ResponseBase<T> Update(T obj);

        ResponseBase<T> Delete(int id);

        jQueryDataTable.DynamicLinq.Result GetList(jQueryDataTable.DynamicLinq.jQueryDataRequest param);
    }
}

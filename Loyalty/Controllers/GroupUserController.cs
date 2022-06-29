using Loyalty.Entities;
using Loyalty.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupUserController : ControllerBase
    {
        private readonly IGroupUserService _GroupUserService;
        public GroupUserController(IGroupUserService unitService)
        {
            _GroupUserService = unitService;
        }

        [HttpGet]
        [Route("{id}")]
        public ResponseBase<Entities.Master.GroupUser> Get(int id)
        {
            return _GroupUserService.Get(id);
        }

        [HttpPost]
        [Route("add")]
        public ResponseBase<Entities.Master.GroupUser> Add([FromBody] Entities.Master.GroupUser GroupUser)
        {
            return _GroupUserService.Add(GroupUser);
        }

        [HttpPost]
        [Route("del/{id}")]
        public ResponseBase<Entities.Master.GroupUser> GetWeatherTypes(int id)
        {
            return _GroupUserService.Delete(id);
        }

        [HttpPost]
        [Route("update")]
        public ResponseBase<Entities.Master.GroupUser> Update([FromBody] Entities.Master.GroupUser GroupUser)
        {
            return _GroupUserService.Update(GroupUser);
        }

        [HttpPost]
        [Route("getlist")]
        public jQueryDataTable.DynamicLinq.Result GetList(jQueryDataTable.DynamicLinq.jQueryDataRequest param)
        {
            return _GroupUserService.GetList(param);
        }
    }
}

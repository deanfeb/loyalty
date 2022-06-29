using Loyalty.Entities;
using Loyalty.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _RoleService;
        public RoleController(IRoleService unitService)
        {
            _RoleService = unitService;
        }

        [HttpGet]
        [Route("{id}")]
        public ResponseBase<Entities.Master.Role> Get(int id)
        {
            return _RoleService.Get(id);
        }

        [HttpPost]
        [Route("add")]
        public ResponseBase<Entities.Master.Role> Add([FromBody] Entities.Master.Role Role)
        {
            return _RoleService.Add(Role);
        }

        [HttpPost]
        [Route("del/{id}")]
        public ResponseBase<Entities.Master.Role> GetWeatherTypes(int id)
        {
            return _RoleService.Delete(id);
        }

        [HttpPost]
        [Route("update")]
        public ResponseBase<Entities.Master.Role> Update([FromBody] Entities.Master.Role Role)
        {
            return _RoleService.Update(Role);
        }

        [HttpPost]
        [Route("getlist")]
        public jQueryDataTable.DynamicLinq.Result GetList(jQueryDataTable.DynamicLinq.jQueryDataRequest param)
        {
            return _RoleService.GetList(param);
        }
    }
}

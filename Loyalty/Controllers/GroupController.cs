using Loyalty.Entities;
using Loyalty.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _GroupService;
        public GroupController(IGroupService unitService)
        {
            _GroupService = unitService;
        }

        [HttpGet]
        [Route("{id}")]
        public ResponseBase<Entities.Master.Group> Get(int id)
        {
            return _GroupService.Get(id);
        }

        [HttpPost]
        [Route("add")]
        public ResponseBase<Entities.Master.Group> Add([FromBody] Entities.Master.Group Group)
        {
            return _GroupService.Add(Group);
        }

        [HttpPost]
        [Route("del/{id}")]
        public ResponseBase<Entities.Master.Group> GetWeatherTypes(int id)
        {
            return _GroupService.Delete(id);
        }

        [HttpPost]
        [Route("update")]
        public ResponseBase<Entities.Master.Group> Update([FromBody] Entities.Master.Group Group)
        {
            return _GroupService.Update(Group);
        }

        [HttpPost]
        [Route("getlist")]
        public jQueryDataTable.DynamicLinq.Result GetList(jQueryDataTable.DynamicLinq.jQueryDataRequest param)
        {
            return _GroupService.GetList(param);
        }
    }
}

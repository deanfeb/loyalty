using Loyalty.Entities;
using Loyalty.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupMenuController : ControllerBase
    {
        private readonly IGroupMenuService _GroupMenuService;
        public GroupMenuController(IGroupMenuService unitService)
        {
            _GroupMenuService = unitService;
        }

        [HttpGet]
        [Route("{id}")]
        public ResponseBase<Entities.Master.GroupMenu> Get(int id)
        {
            return _GroupMenuService.Get(id);
        }

        [HttpPost]
        [Route("add")]
        public ResponseBase<Entities.Master.GroupMenu> Add([FromBody] Entities.Master.GroupMenu GroupMenu)
        {
            return _GroupMenuService.Add(GroupMenu);
        }

        [HttpPost]
        [Route("del/{id}")]
        public ResponseBase<Entities.Master.GroupMenu> GetWeatherTypes(int id)
        {
            return _GroupMenuService.Delete(id);
        }

        [HttpPost]
        [Route("update")]
        public ResponseBase<Entities.Master.GroupMenu> Update([FromBody] Entities.Master.GroupMenu GroupMenu)
        {
            return _GroupMenuService.Update(GroupMenu);
        }

        [HttpPost]
        [Route("getlist")]
        public jQueryDataTable.DynamicLinq.Result GetList(jQueryDataTable.DynamicLinq.jQueryDataRequest param)
        {
            return _GroupMenuService.GetList(param);
        }
    }
}

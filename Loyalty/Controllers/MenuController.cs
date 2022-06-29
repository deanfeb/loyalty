using Loyalty.Entities;
using Loyalty.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _MenuService;
        public MenuController(IMenuService unitService)
        {
            _MenuService = unitService;
        }

        [HttpGet]
        [Route("{id}")]
        public ResponseBase<Entities.Master.Menu> Get(int id)
        {
            return _MenuService.Get(id);
        }

        [HttpPost]
        [Route("add")]
        public ResponseBase<Entities.Master.Menu> Add([FromBody] Entities.Master.Menu Menu)
        {
            return _MenuService.Add(Menu);
        }

        [HttpPost]
        [Route("del/{id}")]
        public ResponseBase<Entities.Master.Menu> GetWeatherTypes(int id)
        {
            return _MenuService.Delete(id);
        }

        [HttpPost]
        [Route("update")]
        public ResponseBase<Entities.Master.Menu> Update([FromBody] Entities.Master.Menu Menu)
        {
            return _MenuService.Update(Menu);
        }

        [HttpPost]
        [Route("getlist")]
        public jQueryDataTable.DynamicLinq.Result GetList(jQueryDataTable.DynamicLinq.jQueryDataRequest param)
        {
            return _MenuService.GetList(param);
        }
    }
}

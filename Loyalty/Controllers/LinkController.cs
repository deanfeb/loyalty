using Loyalty.Entities;
using Loyalty.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly ILinkService _LinkService;
        public LinkController(ILinkService unitService)
        {
            _LinkService = unitService;
        }

        [HttpGet]
        [Route("{id}")]
        public ResponseBase<Entities.Transaction.Link> Get(int id)
        {
            return _LinkService.Get(id);
        }

        [HttpPost]
        [Route("add")]
        public ResponseBase<Entities.Transaction.Link> Add([FromBody] Entities.Transaction.Link Link)
        {
            return _LinkService.Add(Link);
        }

        [HttpPost]
        [Route("del/{id}")]
        public ResponseBase<Entities.Transaction.Link> GetWeatherTypes(int id)
        {
            return _LinkService.Delete(id);
        }

        [HttpPost]
        [Route("update")]
        public ResponseBase<Entities.Transaction.Link> Update([FromBody] Entities.Transaction.Link Link)
        {
            return _LinkService.Update(Link);
        }

        [HttpPost]
        [Route("getlist")]
        public jQueryDataTable.DynamicLinq.Result GetList(jQueryDataTable.DynamicLinq.jQueryDataRequest param)
        {
            return _LinkService.GetList(param);
        }
    }
}

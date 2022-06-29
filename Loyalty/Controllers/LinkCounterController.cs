using Loyalty.Entities;
using Loyalty.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkCounterController : ControllerBase
    {
        private readonly ILinkCounterService _LinkCounterService;
        public LinkCounterController(ILinkCounterService unitService)
        {
            _LinkCounterService = unitService;
        }

        [HttpGet]
        [Route("{id}")]
        public ResponseBase<Entities.Transaction.LinkCounter> Get(int id)
        {
            return _LinkCounterService.Get(id);
        }

        [HttpPost]
        [Route("add")]
        public ResponseBase<Entities.Transaction.LinkCounter> Add([FromBody] Entities.Transaction.LinkCounter LinkCounter)
        {
            return _LinkCounterService.Add(LinkCounter);
        }

        [HttpPost]
        [Route("del/{id}")]
        public ResponseBase<Entities.Transaction.LinkCounter> GetWeatherTypes(int id)
        {
            return _LinkCounterService.Delete(id);
        }

        [HttpPost]
        [Route("update")]
        public ResponseBase<Entities.Transaction.LinkCounter> Update([FromBody] Entities.Transaction.LinkCounter LinkCounter)
        {
            return _LinkCounterService.Update(LinkCounter);
        }

        [HttpPost]
        [Route("getlist")]
        public jQueryDataTable.DynamicLinq.Result GetList(jQueryDataTable.DynamicLinq.jQueryDataRequest param)
        {
            return _LinkCounterService.GetList(param);
        }
    }
}

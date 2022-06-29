using Loyalty.Entities;
using Loyalty.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KoordinatorController : ControllerBase
    {
        private readonly IKoordinatorService _KoordinatorService;
        public KoordinatorController(IKoordinatorService unitService)
        {
            _KoordinatorService = unitService;
        }

        [HttpGet]
        [Route("{id}")]
        public ResponseBase<Entities.Transaction.Koordinator> Get(int id)
        {
            return _KoordinatorService.Get(id);
        }

        [HttpPost]
        [Route("add")]
        public ResponseBase<Entities.Transaction.Koordinator> Add([FromBody] Entities.Transaction.Koordinator Koordinator)
        {
            return _KoordinatorService.Add(Koordinator);
        }

        [HttpPost]
        [Route("del/{id}")]
        public ResponseBase<Entities.Transaction.Koordinator> GetWeatherTypes(int id)
        {
            return _KoordinatorService.Delete(id);
        }

        [HttpPost]
        [Route("update")]
        public ResponseBase<Entities.Transaction.Koordinator> Update([FromBody] Entities.Transaction.Koordinator Koordinator)
        {
            return _KoordinatorService.Update(Koordinator);
        }

        [HttpPost]
        [Route("getlist")]
        public jQueryDataTable.DynamicLinq.Result GetList(jQueryDataTable.DynamicLinq.jQueryDataRequest param)
        {
            return _KoordinatorService.GetList(param);
        }
    }
}

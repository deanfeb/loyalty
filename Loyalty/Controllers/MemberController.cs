using Loyalty.Entities;
using Loyalty.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _MemberService;
        public MemberController(IMemberService unitService)
        {
            _MemberService = unitService;
        }

        [HttpGet]
        [Route("{id}")]
        public ResponseBase<Entities.Transaction.Member> Get(int id)
        {
            return _MemberService.Get(id);
        }

        [HttpPost]
        [Route("add")]
        public ResponseBase<Entities.Transaction.Member> Add([FromBody] Entities.Transaction.Member Member)
        {
            return _MemberService.Add(Member);
        }

        [HttpPost]
        [Route("del/{id}")]
        public ResponseBase<Entities.Transaction.Member> GetWeatherTypes(int id)
        {
            return _MemberService.Delete(id);
        }

        [HttpPost]
        [Route("update")]
        public ResponseBase<Entities.Transaction.Member> Update([FromBody] Entities.Transaction.Member Member)
        {
            return _MemberService.Update(Member);
        }

        [HttpPost]
        [Route("getlist")]
        public jQueryDataTable.DynamicLinq.Result GetList(jQueryDataTable.DynamicLinq.jQueryDataRequest param)
        {
            return _MemberService.GetList(param);
        }
    }
}

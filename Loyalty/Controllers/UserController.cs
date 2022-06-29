using Loyalty.Entities;
using Loyalty.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;
        public UserController(IUserService unitService)
        {
            _UserService = unitService;
        }

        [HttpGet]
        [Route("{id}")]
        public ResponseBase<Entities.Master.User> Get(int id)
        {
            return _UserService.Get(id);
        }

        [HttpPost]
        [Route("add")]
        public ResponseBase<Entities.Master.User> Add([FromBody] Entities.Master.User User)
        {
            return _UserService.Add(User);
        }

        [HttpPost]
        [Route("del/{id}")]
        public ResponseBase<Entities.Master.User> GetWeatherTypes(int id)
        {
            return _UserService.Delete(id);
        }

        [HttpPost]
        [Route("update")]
        public ResponseBase<Entities.Master.User> Update([FromBody] Entities.Master.User User)
        {
            return _UserService.Update(User);
        }

        [HttpPost]
        [Route("getlist")]
        public jQueryDataTable.DynamicLinq.Result GetList(jQueryDataTable.DynamicLinq.jQueryDataRequest param)
        {
            return _UserService.GetList(param);
        }
    }
}

using Loyalty.Entities;
using Loyalty.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _ProjectService;
        public ProjectController(IProjectService unitService)
        {
            _ProjectService = unitService;
        }

        [HttpGet]
        [Route("{id}")]
        public ResponseBase<Entities.Transaction.Project> Get(int id)
        {
            return _ProjectService.Get(id);
        }

        [HttpPost]
        [Route("add")]
        public ResponseBase<Entities.Transaction.Project> Add([FromBody] Entities.Transaction.Project Project)
        {
            return _ProjectService.Add(Project);
        }

        [HttpPost]
        [Route("del/{id}")]
        public ResponseBase<Entities.Transaction.Project> GetWeatherTypes(int id)
        {
            return _ProjectService.Delete(id);
        }

        [HttpPost]
        [Route("update")]
        public ResponseBase<Entities.Transaction.Project> Update([FromBody] Entities.Transaction.Project Project)
        {
            return _ProjectService.Update(Project);
        }

        [HttpPost]
        [Route("getlist")]
        public jQueryDataTable.DynamicLinq.Result GetList(jQueryDataTable.DynamicLinq.jQueryDataRequest param)
        {
            return _ProjectService.GetList(param);
        }
    }
}

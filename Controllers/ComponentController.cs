using ComponentsUIAPI.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComponentsUIAPI.Controllers
{
    [Route("Component")]
    public class ComponentController : Controller
    {
        public readonly ComponentsService _service;
        public ComponentController(ComponentsService service)
        {
            _service = service;
        }

        [HttpGet("CategoryList")]
        public IActionResult GetCategoryList()
        {
            try
            {
                return Ok(_service.GetComponentCategoryList());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace singleton_scoped_transient.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        SingletonService _singletonService;
        ScopedService _scopedService;
        TransientService _transientService;
        Example _example;

        public ValuesController(SingletonService singletonService, ScopedService scopedService, TransientService transientService, Example example)
        {
            _singletonService = singletonService;
            _scopedService = scopedService;
            _transientService = transientService;
            _example = example;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _singletonService.Liste.Add("singleton test");
            _scopedService.Liste.Add("scoped test");
            _transientService.Liste.Add("transient test");

            _example.olustur();
            return Ok();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.ErrorHandling;
using Api.ErrorHandling.Models;
using CodeJam2018.PlatformApi.Models;
using CodeJam2018.PlatformTypes;
using Microsoft.AspNetCore.Mvc;

namespace CodeJam2018.PlatformApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformService _platformService;
        private readonly IErrorCreator _errorCreator;

        public PlatformController(IPlatformService platformService, IErrorCreator errorCreator)
        {
            _platformService = platformService;
            _errorCreator = errorCreator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(_platformService.ReadAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var (platform, errorResult) = _platformService.Read(id);

            if (errorResult != ErrorResult.None)
            {
                return new NotFoundObjectResult(_errorCreator.CreateNotFound(id, Guid.NewGuid().ToString()));
            }

            return new OkObjectResult(platform);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IPlatform platform)
        {
            var (createdPlatform, errorResult) = _platformService.Create(platform);

            if (errorResult != ErrorResult.None)
            {
                return new InternalErrorObjectResult(_errorCreator.CreateApplicationError(new[] { $"Could not create platform.", errorResult.Message }.ToList(), Guid.NewGuid().ToString()));
            }

            return new OkObjectResult(createdPlatform);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] IPlatform platform)
        {
            var (updatedPlatform, errorResult) = _platformService.Update(platform);

            if (errorResult != ErrorResult.None)
            {
                return new InternalErrorObjectResult(_errorCreator.CreateApplicationError(new[] { $"Could not update platform with Id:'{id}'", errorResult.Message }.ToList(), Guid.NewGuid().ToString()));
            }

            return new OkObjectResult(updatedPlatform);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var errorResult = _platformService.Delete(id);

            if (errorResult != ErrorResult.None)
            {
                return new InternalErrorObjectResult(_errorCreator.CreateApplicationError(new[] { $"Could not delete platform with Id:'{id}'", errorResult.Message }.ToList(), Guid.NewGuid().ToString()));
            }

            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Resource.Application.Dto;
using Resource.Core.Abstracts.IProviders;
using Resource.Core.Abstracts.IServices;
using Resource.Enums;
using Yangtao.Hosting.Controller;

namespace Resource.Application.Controllers
{
    public class EnvironmentController : BaseApiController
    {
        private readonly IEnvironmentProvider _environmentProvider;
        private readonly IEnvironmentService _environmentService;

        public EnvironmentController(IEnvironmentProvider environmentProvider)
        {
            _environmentProvider = environmentProvider;
        }

        [HttpPost]
        public async Task Add([FromBody] EnvironmentDto dto)
        {
            await _environmentService.AddAsync(dto.GetEnvironment());
        }

        [HttpDelete]
        public async Task Delete([FromBody] EnvironmentDtoBase dto)
        {
            await _environmentService.RemoveAsync(dto.EnvironmentCode);
        }

        [HttpPut]
        public async Task Modify([FromBody] EnvironmentDto dto)
        {
            await _environmentService.UpdateAsync(dto.GetEnvironment());
        }

        [HttpPatch]
        public async Task Use([FromBody] EnvironmentDtoBase dto)
        {
            await _environmentService.SetEnvironmentStatus(dto.EnvironmentCode, EnvironmentStatus.Useing);
        }

        [HttpPatch]
        public async Task Discard([FromBody] EnvironmentDtoBase dto)
        {
            await _environmentService.SetEnvironmentStatus(dto.EnvironmentCode, EnvironmentStatus.Discarded);
        }

        [HttpGet]
        public async Task<EnvironmentPaginationResult> List([FromQuery] EnvironmentQueryDto dto)
        {
            var queryParams = dto.GetEnvironmentQueryParams();
            var list = await _environmentProvider.GetEnvironmentsAsync(queryParams);
            var count = await _environmentProvider.GetEnvironmentCountAsync(queryParams);

            return new EnvironmentPaginationResult(list, count);
        }
    }
}

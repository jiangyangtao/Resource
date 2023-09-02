using Microsoft.AspNetCore.Mvc;
using Resource.Application.Dto;
using Resource.Core.Abstracts.IProviders;
using Resource.Core.Abstracts.IServices;
using Yangtao.Hosting.Controller;

namespace Resource.Application.Controllers
{
    public class SystemController : BaseApiController
    {
        private readonly ISystemProvider _systemProvider;
        private readonly ISystemService _systemService;

        public SystemController(ISystemProvider systemProvider, ISystemService systemService)
        {
            _systemProvider = systemProvider;
            _systemService = systemService;
        }

        [HttpPost]
        public Task Add([FromBody] SystemDto dto) => _systemService.AddAsymc(dto.GetSystem());


        [HttpDelete]
        public Task Remove([FromBody] SystemDtoBase dto) => _systemService.RemoveAsync(dto.SystemCode);


        [HttpPut]
        public Task Modify([FromBody] SystemDto dto) => _systemService.UpdateAsymc(dto.GetSystem());

        [HttpGet]
        public async Task<SystemPaginationResult> List([FromQuery] SystemQueryDto dto)
        {
            var queryParams = dto.GetSystemQueryParams();
            var list = await _systemProvider.GetSystemsAsync(queryParams);
            var count = await _systemProvider.GetSystemCountAsync(queryParams);

            return new SystemPaginationResult(list, count);
        }
    }
}
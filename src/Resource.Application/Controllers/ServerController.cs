using Microsoft.AspNetCore.Mvc;
using Resource.Application.Dto;
using Resource.Core.Abstracts.IProviders;
using Resource.Core.Abstracts.IServices;
using Yangtao.Hosting.Controller;

namespace Resource.Application.Controllers
{
    public class ServerController : BaseApiController
    {
        private readonly IServerProvider _serverProvider;
        private readonly IServerService _serverService;

        public ServerController(IServerProvider serverProvider, IServerService serverService)
        {
            _serverProvider = serverProvider;
            _serverService = serverService;
        }

        [HttpGet]
        public Task Add([FromBody] ServerDto dto) => _serverService.AddAsync(dto.GetServer());

        [HttpDelete]
        public Task Remove([FromBody] ServerDtoBase dto) => _serverService.RemoveAsync(dto.ServerInstanceId);

        [HttpPut]
        public Task Modify([FromBody] ServerDto dto) => _serverService.UpdateAsync(dto.GetServer());

        [HttpGet]
        public async Task<ServerPaginationResult> List([FromQuery] ServerQueryDto dto)
        {
            var queryParams = dto.GetServerQueryParams();
            var list = await _serverProvider.GetServersAsync(queryParams);
            var count = await _serverProvider.GetServerCountAsync(queryParams);

            return new ServerPaginationResult(list, count);
        }
    }
}

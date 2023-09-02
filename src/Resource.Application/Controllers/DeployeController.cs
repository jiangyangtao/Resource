using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Resource.Application.Dto;
using Resource.Core.Abstracts.IProviders;
using Yangtao.Hosting.Controller;

namespace Resource.Application.Controllers
{
    public class DeployeController : BaseApiController
    {
        private readonly IDeployeProvider _deployeProvider;

        public DeployeController(IDeployeProvider deployeProvider)
        {
            _deployeProvider = deployeProvider;
        }

        [HttpPost]
        public Task Deploye([FromBody] DeployeDto dto) => _deployeProvider.DeployeAsync(dto.ApplicationCode, dto.ServerInstanceId);

        [HttpDelete]
        public Task UnDeploye([FromBody] DeployeDto dto) => _deployeProvider.UnDeployeAsync(dto.ApplicationCode, dto.ServerInstanceId);

        [HttpGet]
        public async Task<ServerDeployeResult[]> ServerDeployes([FromBody] ApplicationDtoBase dto)
        {
            var servers = await _deployeProvider.GetServerDeployesAsync(dto.ApplicationCode);
            if (servers.IsNullOrEmpty()) return Array.Empty<ServerDeployeResult>();

            return servers.Select(a => new ServerDeployeResult(a)).ToArray();
        }

        [HttpGet]
        public async Task<ApplicationResult[]> ApplicationDeployes([FromBody] ServerDtoBase dto)
        {
            var applications = await _deployeProvider.GetApplicationDeployesAsync(dto.ServerInstanceId);
            if (applications.IsNullOrEmpty()) return Array.Empty<ApplicationResult>();

            return applications.Select(a => new ApplicationResult(a)).ToArray();
        }
    }
}

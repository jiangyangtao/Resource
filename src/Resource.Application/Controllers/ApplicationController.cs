using Microsoft.AspNetCore.Mvc;
using Resource.Application.Dto;
using Resource.Core.Abstracts.IProviders;
using Resource.Core.Abstracts.IServices;
using Yangtao.Hosting.Controller;

namespace Resource.Application.Controllers
{
    public class ApplicationController : BaseApiController
    {
        private readonly IApplicationProvider _applicationProvider;
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationProvider applicationProvider, IApplicationService applicationService)
        {
            _applicationProvider = applicationProvider;
            _applicationService = applicationService;
        }

        [HttpPost]
        public async Task Add([FromBody] ApplicationDto dto)
        {
            await _applicationService.AddAsync(dto.GetApplication());
        }

        [HttpDelete]
        public async Task Remove([FromBody] ApplicationDtoBase dto)
        {
            await _applicationService.RemoveAsync(dto.ApplicationCode);
        }

        [HttpPut]
        public async Task Modify([FromBody] ApplicationDto dto)
        {
            await _applicationService.UpdateAsync(dto.GetApplication());
        }

        [HttpGet]
        public async Task<ApplicationPaginationResult> List([FromBody] ApplicationQueryDto dto)
        {
            var queryParams = dto.GetApplicationQueryParams();
            var list = await _applicationProvider.GetApplicationsAsync(queryParams);
            var count = await _applicationProvider.GetApplicationCountAsync(queryParams);

            return new ApplicationPaginationResult(list, count);
        }

        [HttpGet]
        public async Task<ApplicationResult> Get([FromQuery] ApplicationDtoBase dto)
        {
            var application = await _applicationProvider.GetApplicationAsync(dto.ApplicationCode);
            if (application == null) ResponseNotFound("Not found.");

            return new ApplicationResult(application);
        }
    }
}

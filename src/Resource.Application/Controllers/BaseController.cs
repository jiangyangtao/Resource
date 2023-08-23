using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yangtao.Hosting.Controller;

namespace Resource.Application.Controllers
{
    [Route("v1/api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public abstract class BaseController : HttpResultController
    {
        protected BaseController()
        {
        }
    }
}

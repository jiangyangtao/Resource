using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.Core.Abstracts.IProviders
{
    public interface IDeployeProvider
    {
        Task DeployeAsync(string applicationCode, string serverInstanceId);

        Task UnDeployeAsync(string applicationCode, string serverInstanceId);
    }
}

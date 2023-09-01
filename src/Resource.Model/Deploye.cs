using Yangtao.Hosting.Repository.Abstractions;

namespace Resource.Model
{
    public class Deploye : BaseEntity
    {
        public string ServerInstanceId { set; get; }

        public string ApplicationCode { set; get; }
    }
}

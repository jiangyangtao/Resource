using Yangtao.Hosting.Common;

namespace Resource.Repository.Abstractions
{
    public abstract class BaseEntity : IEntity
    {
        protected BaseEntity()
        {
            Id = SequentialGuidGenerator.NewSequentialGuid(SequentialGuidType.SequentialAsString).ToString();
        }

        public string Id { get ; set ; }

        public DateTime CreateTime { get ; set ; }

        public DateTime UpdateTime { get ; set ; }

        public string? CreateUser { get ; set ; }

        public string? UpdateUser { get ; set ; }
    }
}

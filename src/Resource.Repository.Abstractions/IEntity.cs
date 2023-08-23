
namespace Resource.Repository.Abstractions
{
    public interface IEntity
    {
        public string Id { get; set; }

        public DateTime CreateTime { set; get; }

        public DateTime UpdateTime { set; get; }

        public string? CreateUser { set; get; }

        public string? UpdateUser { set; get; }
    }
}
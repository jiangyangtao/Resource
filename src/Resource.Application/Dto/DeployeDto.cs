using System.ComponentModel.DataAnnotations;

namespace Resource.Application.Dto
{
    public class DeployeDto : ServerDtoBase
    {
        [Required]
        public string ApplicationCode { set; get; }
    }
}

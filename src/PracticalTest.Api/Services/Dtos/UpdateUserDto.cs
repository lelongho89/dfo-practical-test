using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PracticalTestApi.Services.Dtos
{
    public class UpdateUserDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Age must be greater than zero.")]
        public int? Age { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }
    }
}

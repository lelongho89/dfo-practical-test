using Newtonsoft.Json;

namespace PracticalTestApi.Services.Dtos
{
    public class UpdateUserDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}

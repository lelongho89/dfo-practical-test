using System.ComponentModel.DataAnnotations;

namespace PracticalTestApi.Services.Dtos
{
    public class ErrorDto
    {
        [Display(Description = "Error message.")]
        public string Message { get; set; }

        [Display(Description = "Detailed error messages.")]
        public string[] Details { get; set; }

        [Display(Description = "Status code of the http response.")]
        public int? StatusCode { get; set; } = 400;
    }
}

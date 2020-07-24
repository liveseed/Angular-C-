
using System.ComponentModel.DataAnnotations;

namespace AngularDotNetProject.API.DTOs
{
    public class ReleaseDto
    {
        public int ReleaseId { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public decimal Price { get; set; }
        public string DateMin { get; set; }
        public string DateMax { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        [Range(2, 120000, ErrorMessage = "{0} must be between 2 and 120000")]
        public int Quantity { get; set; }
    }
}

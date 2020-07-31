using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace AngularDotNetProject.API.DTOs
{
    public class EventDto
    {
        public int EventId { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(100, MinimumLength =3, ErrorMessage ="{0} must be between 3 and 100 characters")]
        public string Location { get; set; }
        public string EventDate { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public string Type { get; set; }

        [Required(ErrorMessage="Name is required.")]
        public string Name { get; set; }

        [Range(2,120000, ErrorMessage = "Quantity is between 2 and 120000")]
        public int Capacity { get; set; }
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        //[Phone]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        [EmailAddress]
        public string Email { get; set; }
        public List<ReleaseDto> Releases { get; set; }
        public List<SocialNetworkDto> SocialNetworks { get; set; }
        public List<HeadlineDto> Headlines { get; set; }
    }
}

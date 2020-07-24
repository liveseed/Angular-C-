using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AngularDotNetProject.API.DTOs
{
    public class HeadlineDto
    {
        public int HeadlineId { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public string Name { get; set; }
        public string HighLight { get; set; }
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        [EmailAddress]
        public string Email { get; set; }
        public List<EventDto> Events { get; set; }
        public List<SocialNetworkDto> SocialNetworks { get; set; }
    }
}

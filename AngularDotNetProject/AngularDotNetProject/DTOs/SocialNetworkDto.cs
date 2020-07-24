
using System.ComponentModel.DataAnnotations;

namespace AngularDotNetProject.API.DTOs
{
    public class SocialNetworkDto
    {
        public int SocialNetworkId { get; set; }

        [Required(ErrorMessage ="You must enter {0}")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "You must enter {0}")]
        public string URL { get; set; }
    }
}

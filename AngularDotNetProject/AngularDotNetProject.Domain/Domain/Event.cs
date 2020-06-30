using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDotNetProject.Domain.Domain
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string Location { get; set; }
        public DateTime? EventDate { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<Release> Releases { get; set; }
        public List<SocialNetwork> SocialNetworks { get; set; }
        public List<HeadlineEvent> HeadlineEvents { get; set; }



    }
}

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
        public int EventId { get; private set; }
        public string Location { get; private set; }
        public DateTime? EventDate { get; private set; }
        public string Type { get; private set; }
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public string ImageURL { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public List<Release> Releases { get; set; }
        public List<SocialNetwork> SocialNetworks { get; set; }
        public List<HeadlineEvent> HeadlineEvents { get; set; }



    }
}

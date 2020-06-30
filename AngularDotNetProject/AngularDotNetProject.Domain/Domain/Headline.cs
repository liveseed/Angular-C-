using System;
using System.Collections.Generic;
using System.Text;

namespace AngularDotNetProject.Domain.Domain
{
    public class Headline
    {
        public int HeadlineId { get; set; }
        public string Name { get; set; }
        public string HighLight { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<HeadlineEvent> HeadlineEvents { get; set; }
        public List<SocialNetwork> SocialNetworks { get; set; }
        

    }
}

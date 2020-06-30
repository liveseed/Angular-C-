using System;
using System.Collections.Generic;
using System.Text;

namespace AngularDotNetProject.Domain.Domain
{
    public class SocialNetwork
    {
        public int SocialNetworkId { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public int? EventId { get; set; }
        public Event Event { get; }
        public int? HeadlineId { get; set; }
        public Headline Headline { get; }
    }
}

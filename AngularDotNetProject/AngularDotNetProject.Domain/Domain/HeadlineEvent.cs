using System;
using System.Collections.Generic;
using System.Text;

namespace AngularDotNetProject.Domain.Domain
{
    public class HeadlineEvent
    {
        public int HeadlineId { get; set; }
        public Headline Headline { get; set; }
        public Event Event { get; set; }
        public int EventId { get; set; }
    }
}

/*HeadlineId === EventId
    1              1 
    1              2
    1              3
    2              1    */


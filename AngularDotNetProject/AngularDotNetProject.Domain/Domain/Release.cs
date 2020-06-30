using System;
using System.Collections.Generic;
using System.Text;

namespace AngularDotNetProject.Domain.Domain
{
    public class Release
    {
        public int ReleaseId { get; set; }
        public string Name  { get; set; }
        public decimal Price { get; set; }
        public DateTime? DateMin { get; set; }
        public DateTime? DateMax { get; set; }
        public int Quantity { get; set; }
        public int EventId { get; set; }
        public Event Event { get; }
    }
}

using System.Collections.Generic;

namespace VUTTR.Domain.Models
{
    public class Tool
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public virtual List<Tag> Tags { get; set; }
    }
}
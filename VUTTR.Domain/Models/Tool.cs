using System.Collections.Generic;
using VUTTR.Domain.ViewModels;

namespace VUTTR.Domain.Models
{
    public class Tool
    {
        public int id { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public virtual List<Tag> Tags { get; set; }
    }
}
using System.Collections.Generic;
using VUTTR.Domain.Models;

namespace VUTTR.Domain.ViewModels
{
    public class ToolViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public List<TagViewModel> Tags { get; set; }
    }
}
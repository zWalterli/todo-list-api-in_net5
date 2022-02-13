using System.Collections.Generic;
using VUTTR.Domain.Models;

namespace VUTTR.Domain.ViewModels
{
    public class ToolViewModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public List<TagViewModel> Tags { get; set; }
    }
}
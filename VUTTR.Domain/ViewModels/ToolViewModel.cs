using System.Collections.Generic;
using VUTTR.Domain.Models;

namespace VUTTR.Domain.ViewModels
{
    public class ToolViewModel
    {
        public ToolViewModel() { }
        public ToolViewModel(Tool toolModel)
        {
            this.id = toolModel.id;
            this.title = toolModel.title;
            this.link = toolModel.link;
            this.description = toolModel.description;

            if (toolModel.Tags != null)
            {
                List<string> listTags = new List<string>();
                foreach (var tag in toolModel.Tags)
                {
                    listTags.Add(tag.description);
                }

                this.Tags = listTags;
            }
        }

        public int id { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public List<string> Tags { get; set; }
    }
}
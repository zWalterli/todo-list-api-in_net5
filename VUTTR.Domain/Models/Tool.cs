using System.Collections.Generic;
using VUTTR.Domain.DTOs;

namespace VUTTR.Domain.Models
{
    public class Tool
    {
        #region Constructor            
        public Tool() { }
        public Tool(ToolDto toolDto)
        {
            this.id = toolDto.id;
            this.title = toolDto.title;
            this.link = toolDto.link;
            this.description = toolDto.description;

            List<Tag> tagsList = new List<Tag>();
            if (toolDto.Tags != null)
            {
                foreach (var tag in toolDto.Tags)
                {
                    Tag tagTemp = new Tag();
                    tagTemp.description = tag;
                    tagsList.Add(tagTemp);
                }
                this.Tags = tagsList;
            }
        }
        #endregion

        public int id { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public virtual List<Tag> Tags { get; set; }
    }
}
namespace VUTTR.Domain.Models
{
    public class Tag
    {
        public Tag() { }
        public Tag(Tag tag)
        {
            Id = tag.Id;
            ToolId = tag.ToolId;
            Description = tag.Description;
            Tool = tag.Tool;
        }

        public int? Id { get; set; }
        public int ToolId { get; set; }
        public string Description { get; set; }
        public bool Ativo { get; set; }
        public virtual Tool Tool { get; set; }

        public Tag Clone()
        {
            return new Tag(this);
        }
    }
}
namespace VUTTR.Domain.Models
{
    public class Tag
    {
        public int id { get; set; }
        public string description { get; set; }
        public virtual Tool Tool { get; set; }
    }
}
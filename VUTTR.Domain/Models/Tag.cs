using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VUTTR.Domain.Models
{
    public class Tag
    {
        [Key]  
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string description { get; set; }
        public virtual Tool Tool { get; set; }
    }
}
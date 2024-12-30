using System.ComponentModel.DataAnnotations;

namespace WebHeroCreator.Models
{
    public class PowerAttributes
    {
        [Key]
        public int AttributeId { get; set; }
        public string Attribute { get; set; }
    }
}

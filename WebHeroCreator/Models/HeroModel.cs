using System.ComponentModel.DataAnnotations;

namespace WebHeroCreator.Models
{
    public class HeroModel
    {
        [Key]
        public int HeroId { get; set; }

        public string Name { get; set; }

        public string PowerAttribute { get; set; }

        public string ClanName { get; set; }
    }
}

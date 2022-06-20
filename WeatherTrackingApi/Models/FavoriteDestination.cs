using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherTrackingApi.Models
{
    public class FavoriteDestination
    {
        [Key, Column(Order = 1)]
        [ForeignKey("Account")]
        public int UserId { get; set; }
        
        [Key, Column(Order = 2)]
        [ForeignKey("City")]
        public int CityId { get; set; }
        
        [Required]
        public int TimeVisit { get; set; }
        
        [Required]
        public int AverageTravelTimeInSec { get; set; }
        
        public virtual Account Account { get; set; }
        public virtual City City { get; set; }
    }
}
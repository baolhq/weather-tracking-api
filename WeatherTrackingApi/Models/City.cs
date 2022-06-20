using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherTrackingApi.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string CityName { get; set; }

        [Required]
        public byte TimeZone { get; set; }

        [Required]
        public float Longitude { get; set; }

        [Required]
        public float Latitude { get; set; }

        public virtual BookingSchedule BookingSchedule { get; set; }
        public virtual SuggestBoard SuggestBoard { get; set; }
        public virtual WeatherStatus WeatherStatus { get; set; }
        public virtual FavoriteDestination FavoriteDestination { get; set; }
    }
}
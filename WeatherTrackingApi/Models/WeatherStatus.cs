using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherTrackingApi.Models
{
    public class WeatherStatus
    {
        [Key]
        public int WeatherId { get; set; }
        
        [Required]
        [ForeignKey("City")]
        public int CityId { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string WeatherName { get; set; }
        
        [Column(TypeName = "varchar(255)")]
        public string WeatherImage { get; set; }
        
        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }
        
        [Required]
        public int TimeStartInSec { get; set; }
        
        [Required]
        public int TimeEndInSec { get; set; }
        
        [Required]
        // Default value is DateTime.Now()
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdated { get; set; }
        
        public float Humidity { get; set; }
        public  float TemperatureInC { get; set; }
        public float WindSpeed { get; set; }
        public float Pressure { get; set; }
        public float UvSunIndex { get; set; }
        
        public virtual City City { get; set; }
        public virtual FavoriteDestination FavoriteDestination { get; set; }
    }
}
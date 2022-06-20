using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherTrackingApi.Models
{
    public class TransportHistory
    {
        [Key]
        public int TransportId { get; set; }
        
        [Required]
        [ForeignKey("Account")]
        public int UserId { get; set; }
        
        [Required]
        public DateTime TimeStart { get; set; }
        
        [Required]
        public DateTime TimeEnd { get; set; }
        
        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string StartPoint { get; set; }
        
        [Required]
        public double Velocity { get; set; }
        
        [Required]
        public int AccurateTravelTimeInSec { get; set; }
        
        public virtual Account Account { get; set; } 
    }
}
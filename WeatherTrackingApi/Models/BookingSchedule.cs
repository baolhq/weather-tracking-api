using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherTrackingApi.Models
{
    public class BookingSchedule
    {
        [Key]
        public int BookingId { get; set; }
        
        [Required]
        [ForeignKey("Account")]
        public  int UserId { get; set; }
        
        [Required]
        [ForeignKey("City")]
        public int CityId { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public  string StartPoint { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public  string EndPoint { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        
        [Column(TypeName = "nvarchar(255)")]
        public  string Description { get; set; }
        
        [Required]
        public double Velocity { get; set; }
        
        public virtual Account Account { get; set; }
        public virtual City City { get; set; }
    }
}
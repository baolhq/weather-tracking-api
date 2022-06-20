using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherTrackingApi.Models
{
    public class Account
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Username { get; set; }

        [Required]
        [Column(TypeName = "varchar(32)")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FullName { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string Email { get; set; }
        
        [DefaultValue(false)]
        public  bool IsEmailValidated { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Address { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Avatar { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime LastLogin { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        [DefaultValue(false)]
        public bool IsAdmin { get; set; }

        public virtual TransportHistory TransportHistory { get; set; }
        public virtual BookingSchedule BookingSchedule { get; set; }
        public virtual FavoriteDestination FavoriteDestination { get; set; }
    }
}
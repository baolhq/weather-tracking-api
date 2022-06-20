using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherTrackingApi.Models
{
    public class SuggestBoard
    {
        [Key]
        public int SuggestId { get; set; }
        
        [Required]
        [ForeignKey("City")]
        public int CityId { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Address { get; set; }
        
        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        public byte TimeZone { get; set; }
        
        public virtual City City { get; set; }
        public List<SuggestBoardImage> SuggestBoardImages { get; set; }
    }
}
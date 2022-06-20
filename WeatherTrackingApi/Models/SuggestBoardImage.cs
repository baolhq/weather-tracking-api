using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherTrackingApi.Models
{
    public class SuggestBoardImage
    {
        [Key]
        public int ImageId { get; set; }
        
        [Required]
        [ForeignKey("SuggestBoard")]
        public int SuggestId { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Image { get; set; }
        
        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }
        
        public SuggestBoard SuggestBoard { get; set; }
    }
}
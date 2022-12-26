using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace practiceAuthentication.Models
{
    public class Practice
    {

        [Key]
        public int ID { get; set; }

        [Column (TypeName ="nvarchar(50)")]
        [DisplayName("First Name")]
        public string? Firstname { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Last Name")]
        public string? Lastname { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Email")]
        public string? Email { get; set; }


        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateToday { get; set; } = DateTime.Now;


        
    }
}

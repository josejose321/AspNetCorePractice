
using System.ComponentModel.DataAnnotations;

namespace practiceAuthentication.Models
{
    public class WorkExperience
    {
        [Key]
        public int ID { get; set; }

        public String? Designation { get; set; }

        public String? JobDescription { get;set; }

        public Practice? user { get; set; }

        public int PracticeId { get; set; }

    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Courses.Models.Entities
{
    public class StudyLevel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<UserRegister> UserRegisters { get; set; }
    }
}

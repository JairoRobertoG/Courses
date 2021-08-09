using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Courses.Models.Entities
{
    public class CourseType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<UserRegister> UserRegisters { get; set; }
    }
}

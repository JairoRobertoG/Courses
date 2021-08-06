using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Courses.Models.Entities
{
    public class UserRegister
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public byte[] ProfileImage { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public StudyLevel StudyLevel { get; set; }

        [Required]
        public CourseType CourseType { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}

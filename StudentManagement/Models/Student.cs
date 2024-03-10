﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        public string? Name { get; set;}

        public string? RollNumber { get; set;}

        public DateTime? DOB { get; set; }

        public string? Phone { get; set;}

        public string? Email { get; set;}

        public string? Gender { get; set;}   

        public string? Address { get; set;}

        public string? Department { get; set;}
    }
}

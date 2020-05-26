using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Domain.Models
{
    public class ApplicantModel
    {
        public int ID { get; set; }
        [Required]
        [StringLength(int.MaxValue, ErrorMessage = "Minimum length of characters should be 5", MinimumLength = 6)]
        public string Name { get; set; }
        [Required]
        [StringLength(int.MaxValue, ErrorMessage = "Minimum length of characters should be 5", MinimumLength = 6)]
        public string FamilyName { get; set; }
        [Required]
        [StringLength(int.MaxValue, ErrorMessage = "Minimum length of characters should be 10", MinimumLength = 10)]
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EMailAdress { get; set; }
        [Range(20, 60)]
        public int Age { get; set; }
        public bool Hired { get; set; }

    }
}

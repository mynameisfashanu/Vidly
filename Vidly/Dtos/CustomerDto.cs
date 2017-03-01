using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the name field")] // Data anntations
        [StringLength(255)]
        public string Name { get; set; }

        // casts to customer object, will cause an exception.
       // [Min18YearsIfAMember] 
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Membership Type Id")]
        public byte MembershipTypeId { get; set; }

    }
}
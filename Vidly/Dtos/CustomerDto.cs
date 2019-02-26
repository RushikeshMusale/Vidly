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

        [Required] //Makes Name not nullable in database
        [StringLength(255)] //Sets column length in db as varchar(255)
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        
        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}
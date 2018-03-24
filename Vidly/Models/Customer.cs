﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required] //Makes Name not nullable in database
        [StringLength(255)] //Sets column length in db as varchar(255)
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        public DateTime Birthdate { get; set; }

        //Navigation Properties
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}
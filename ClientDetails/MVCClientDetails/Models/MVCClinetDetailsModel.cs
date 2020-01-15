using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCClientDetails.Models
{
    public class MVCClinetDetailsModel
    {
        public long ClientDetailsID { get; set; }
        [Required(ErrorMessage ="This field is required.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string PhoneNo { get; set; }
        public string Gender { get; set; }

    }
}
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LawAlert.Infrastructure.Attributes.CustomBirthDate;
using static LawAlert.Infrastructure.Data.DataConstants.User;


namespace LawAlert.Infrastructure.Data.Entities.Accounts
{
    public class User : IdentityUser
    {
        /// <summary>
        /// Contains the first name of the user
        /// </summary>
        [Required]
        [StringLength(UserMaxLengthFirstName, MinimumLength = UserMinLengthFirstName)]
        public string FirstName { get; set; }

        /// <summary>
        /// Contains the last name of the user
        /// </summary>
        [Required]
        [StringLength(UserMaxLengthLastName, MinimumLength = UserMinLengthLastName)]
        public string LastName { get; set; }

        /// <summary>
        /// Contains the phone number of the user
        /// </summary>
        [Required]
        [StringLength(UserLengthPhoneNumber)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Contains the birth date of the user
        /// </summary>
        [Required]
        [CustomBirthDate]
        public DateTime BirthDate { get; set; }

        public virtual List<Interest>? Interests { get; set; } = new List<Interest>();
    }
}

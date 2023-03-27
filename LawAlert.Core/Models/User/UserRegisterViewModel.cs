using LawAlert.Core.Models.Interest;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LawAlert.Core.Attributes.CustomBirthDate;
using static LawAlert.Infrastructure.Data.DataConstants.User;

namespace LawAlert.Core.Models.User
{
    public class UserRegisterViewModel
    {
        [Required]
        [StringLength(UserMaxLengthFirstName, MinimumLength = UserMinLengthFirstName)]
        public string UserName { get; set; }

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

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required]
        [StringLength(UserMaxLengthPassword, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = UserMinLengthPassword)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Contains the interest of the user
        /// </summary>
        [Required]
        public int InterestId { get; set; }

        public List<InterestViewModel>? Interests { get; set; } = new List<InterestViewModel>();
    }
}

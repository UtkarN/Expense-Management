using System.ComponentModel.DataAnnotations;
namespace ExpenseManagement.Models
{
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please Enter First Name ")]
        [MinLength(3, ErrorMessage = "The First name given to is Too Short")]
        [Display(Name = "First Name ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name ")]
        [MinLength(3, ErrorMessage = "The Last name given to is Too Short")]
        [Display(Name = "Last Name ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Email Address ")]
        [MinLength(3, ErrorMessage = "Email Address given to is Too Short")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required (ErrorMessage = "Please Provide the password")]
        public string Password { get; set; }    
    }
}

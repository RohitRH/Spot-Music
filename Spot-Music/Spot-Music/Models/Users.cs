using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spot_Music.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required,EmailAddress]
        public string Email { get; set; }
        [Required,MinLength(3)]
        public string Name { get; set; }
        [Required,DataType(DataType.Password),MinLength(8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}",
         ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")]
        public string Password { get; set; }

        public virtual ICollection<Users_Songs> Users_Songs { get; set; }
    }
}

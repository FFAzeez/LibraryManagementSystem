using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementInfrastructure.Model
{
    public class Customer:IdentityUser
    {
        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdateAt { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}

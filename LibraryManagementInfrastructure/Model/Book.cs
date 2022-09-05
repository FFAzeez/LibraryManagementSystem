using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementInfrastructure.Model
{
    public class Book
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }
        public string CustomerId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Author { get; set; }
        [DataType(DataType.Text)]
        public string Description { get; set; }
        [DataType(DataType.Text)]
        public string Publisher { get; set; }
        [DataType(DataType.Text)]
        public string Language { get; set; }
        [DataType(DataType.Text)]
        public string Edition { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdateAt { get; set; }
        public Issue Issue { get; set; }
    }
}

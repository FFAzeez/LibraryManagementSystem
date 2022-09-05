using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementInfrastructure.Model
{
    public class Issue
    {
        [Key]
        public string Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }
        public int MaxIssueDay { get; set; }
        public bool IsAvailable { get; set; }
        public double Payment { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string BookId { get; set; }
        public Book Book { get; set; }
    }
}

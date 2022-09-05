using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementCore.DTOs.Requests
{
    public class BorrowRequestDto
    {
        public string CustomerId { get; set; }
        public string BookId { get; set; }
    }
}

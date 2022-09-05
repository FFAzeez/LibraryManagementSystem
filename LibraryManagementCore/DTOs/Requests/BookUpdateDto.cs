using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementCore.DTOs.Requests
{
    public class BookUpdateDto
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Edition { get; set; }
    }
}

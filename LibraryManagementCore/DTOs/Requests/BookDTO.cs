using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementCore.DTOs.Request
{
    public class BookDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
        public string Edition { get; set; }
        public bool IsAvailable { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementCore.Utility
{
    public class GetString
    {
        public static string ApiRandomString()
        {
            var str = "devenumcomsoftwaredev01236789";

            var random = new Random();
            var str_builder = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                var alphnumeric_string = str[random.Next(str.Length)];
                str_builder.Append(alphnumeric_string);
            }

            return str;
        }
    }
}

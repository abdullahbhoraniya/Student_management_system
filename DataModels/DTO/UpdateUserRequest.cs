using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.DTO
{
    public class UpdateUserRequest
    {
        public string FullName { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }

        public int? UpdatedBy { get; set; }
    }
}

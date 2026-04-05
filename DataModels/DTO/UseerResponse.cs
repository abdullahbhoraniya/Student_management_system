using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.DTO
{
        public class UserResponse
        {
            public int UserId { get; set; }

            public string FullName { get; set; }

            public string EmailId { get; set; }

            public string PhoneNo { get; set; }

            public string Address { get; set; }

            public string Password { get; set; }

            public int? CreatedBy { get; set; }

            public int? UpdatedBy { get; set; }

            public DateTime? CreatedDate { get; set; }

            public DateTime? UpdateDate { get; set; }
    }
}

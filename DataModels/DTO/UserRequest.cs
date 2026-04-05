using System;

namespace DataModels.DTO
{
    public class UserRequest
    {
        public string FullName { get; set; }

        public string EmailId { get; set; }

        public string PhoneNo { get; set; }

        public string Address { get; set; }

        public string Password { get; set; }

        public int? CreatedBy { get; set; }
    }
}
using System;

namespace DataModels.DTO
{
    public class StudentResponse
    {
        public int StudentId { get; set; }

        public string FullName { get; set; }

        public string EmailId { get; set; }

        public string PhoneNo { get; set; }

        public string Address { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
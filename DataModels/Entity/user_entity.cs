using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Entity
{
    public class Users
    {
        public int stf_id { get; set; }

        public string full_name { get; set; }

        public string email_id { get; set; }

        public string phone_no { get; set; }

        public string address { get; set; }

        public string password { get; set; }

        public int? created_by { get; set; }

        public int? updated_by { get; set; }

        public DateTime? created_date { get; set; }

        public DateTime? update_date { get; set; }

        public string Status { get; set; }
    }
}

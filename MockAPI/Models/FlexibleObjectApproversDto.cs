using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockAPI.Models
{
    public class FlexibleObjectApproversDto
    {
        public int id { get; set; }
        public string status { get; set; }
        public Content content { get; set; }
        public string flexible_object_definition_code { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Approval[] approvals { get; set; }

        public class Content
        {
            public string name { get; set; }
            public int event_id { get; set; }
            public string currency { get; set; }
            public DateTime transaction_effective_date { get; set; }
            public Owner owner { get; set; }
            public Total total { get; set; }
        }

        public class Owner
        {
            public string type { get; set; }
            public int identifier { get; set; }
        }

        public class Total
        {
            public float amount { get; set; }
            public string currency_code { get; set; }
        }

        public class Approval
        {
            public int id { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public int position { get; set; }
            public int? approval_chain_id { get; set; }
            public string status { get; set; }
            public DateTime? approval_date { get; set; }
            public string note { get; set; }
            public string type { get; set; }
            public string approvable_type { get; set; }
            public string approver_type { get; set; }
            public int approvable_id { get; set; }
            public int approver_id { get; set; }
            public int? delegate_id { get; set; }
            public bool holdable { get; set; }
            public Person approver { get; set; }
            public List<string> reasons { get; set; }
            public Person created_by { get; set; }
            public Person updated_by { get; set; }
            public DateTime createdat { get; set; }
            public DateTime updatedat { get; set; }
            public DateTime? approvaldate { get; set; }
            public Person createdby { get; set; }
            public Person updatedby { get; set; }
        }

        public class Person
        {
            public int id { get; set; }
            public string login { get; set; }
            public string email { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string full_name { get; set; }
            public int salesforce_id { get; set; }
            public string avatar_thumb_url { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string fullname { get; set; }
        }
    }
}

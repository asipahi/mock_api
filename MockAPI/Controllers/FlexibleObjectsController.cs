using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockAPI.Models;
using RandomTestValues;

namespace MockAPI.Controllers
{
    [Route("api/flexible_objects")]
    [ApiController]
    public class FlexibleObjectsController : ControllerBase
    {
        public List<string> types = new List<string> { "ManualBeginningApproval", "ApprovalChainApproval" };
        public List<string> statuses = new List<string> { "pending_approval", "escalated", "submitted" };
        public List<string> names = new List<string> {
            "Kylie Bailey",
            "Maria Howard",
            "Christopher Vance",
            "Irene Peake",
            "Evan Thomson",
            "Michael Gibson",
            "Olivia Skinner",
            "Gavin Hodges",
            "Blake Sanderson",
            "Piers Watson" 
        };
        public List<string> reasons = new List<string>
        {
            "Added by the approval chain Test Chain 1",
            "This object exceeds the approval limits of all of the listed approvers.",
            "Acting as Ultimate Approver",
            "Manually added by Coupa Support"
        };

        [HttpGet("instances")]
        [HttpPost("{transactionType}/instances")]
        [HttpPost("instances")]
        [HttpPut("{transactionType}/instances/{id:int}")]
        [HttpPut("{transactionType}/instances/{id:int}/approve")]
        public FlexibleObjectApproversDto Instance(string transactionType)
        {
            var obj = RandomValue.Object<FlexibleObjectApproversDto>();
            var position = 0;
            foreach (var item in obj.approvals)
            {
                item.type = types[RandomValue.Int(1, 0)];
                item.status = position == 0 ? "approved" : statuses[RandomValue.Int(statuses.Count - 1, 0)];
                item.position = position++;
                item.approver.full_name = names[RandomValue.Int(names.Count - 1, 0)];
                item.reasons = new List<string> { reasons[RandomValue.Int(reasons.Count - 1, 0)] };
            }
            return obj;
        }

        [HttpGet("instances/{id:int}/submit_for_approval")]
        [HttpPost("instances/{id:int}/submit_for_approval")]
        [HttpPost("{transactionType}/instances/{id:int}/submit_for_approval")]
        public FlexibleObjectApproversDto SubmitForApproval()
        {
            var obj = RandomValue.Object<FlexibleObjectApproversDto>();
            var position = 1;
            foreach (var item in obj.approvals)
            {
                item.type = types[RandomValue.Int(1, 0)];
                item.status = statuses[RandomValue.Int(3, 0)];
                item.position = position;
                position += 1;                
            }
            return obj;
        }
    }
}
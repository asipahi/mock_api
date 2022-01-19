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
        public List<string> statuses = new List<string> { "pending_approval", "approved", "escalated", "submitted" };
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
                item.status = statuses[RandomValue.Int(statuses.Count - 1, 0)];
                item.position = position++;
                item.approver.full_name = names[RandomValue.Int(names.Count - 1, 0)];
                item.
            }
            return obj;
        }

        [HttpGet("instances/{id:int}/submit_for_approval")]
        [HttpPost("instances/{id:int}/submit_for_approval")]
        public FlexibleObjectApproversDto SubmitForApproval()
        {
            return RandomValue.Object<FlexibleObjectApproversDto>();
        }
    }
}
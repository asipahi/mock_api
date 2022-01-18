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

        [HttpGet("instances")]
        [HttpPost("{transactionType}/instances")]
        [HttpPost("instances")]
        [HttpPut("{transactionType}/instances/{id:int}")]
        public FlexibleObjectApproversDto Instance(string transactionType)
        {
            var obj = RandomValue.Object<FlexibleObjectApproversDto>();
            var position = 1;
            foreach (var item in obj.approvals)
            {
                item.type = types[RandomValue.Int(1, 0)];
                item.status = statuses[RandomValue.Int(3, 0)];
                position += 1;
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
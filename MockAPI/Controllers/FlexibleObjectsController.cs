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
        [HttpGet("instances")]
        [HttpPost("instances")]
        [HttpPut("instances/{id:int}")]
        public FlexibleObjectApproversDto Instance()
        {
            return RandomValue.Object<FlexibleObjectApproversDto>();
        }

        [HttpGet("instances/{id:int}/submit_for_approval")]
        [HttpPost("instances/{id:int}/submit_for_approval")]
        public FlexibleObjectApproversDto SubmitForApproval()
        {
            return RandomValue.Object<FlexibleObjectApproversDto>();
        }
    }
}
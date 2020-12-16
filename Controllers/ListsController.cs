using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using DotnetTaskMaster.Models;
using DotnetTaskMaster.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotnetTaskMaster.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListsController : ControllerBase
    {
        private readonly ListsService _ls; 

        public ListsController(ListsService ls)
        {
            _ls = ls;
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<List>> CreateList([FromBody]List newList)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newList.CreatorId = userInfo.Id;
                List created = _ls.CreateList(newList);
                created.Creator = userInfo;
                return Ok(created);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public ActionResult<IEnumerable<List>> GetLists()
        {
            try
            {
                return Ok(_ls.GetLists());
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
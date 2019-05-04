using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ATM_System.Entity.Models;

namespace ATM_System.WebAPI.Controllers
{
    public class AuthenticationController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Login(CardDetails cardDetails)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            return null;

        }
    }
}

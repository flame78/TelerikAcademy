using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BullsAndCows.Service.Controllers
{
    using BullsAndCows.DAL;
    using BullsAndCows.Models;

    public class BaseApiController : ApiController
    {
        protected IBullsAndCowsData Data;

        public BaseApiController()
            : this(new BullsAndCowsData())
        {
        }

        public BaseApiController(IBullsAndCowsData data)
        {
            this.Data = data;
        }
    
    }
}

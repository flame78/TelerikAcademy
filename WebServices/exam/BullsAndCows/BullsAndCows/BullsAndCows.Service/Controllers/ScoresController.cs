using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BullsAndCows.Service.Controllers
{

    public class ScoresController : BaseApiController
    {
//        HTTP Method	Url endpoint	Description
//GET	/scores	Does not require an authentication. 
//Returns the top 10 players with highest ranks. The rank is calculated using the following formula:
//Rank = winsCount * 100 + lossesCount*15

//        Request
//HTTP Method:	GET	URL:	http://localhost:XXXXX/api/scores 
//Headers	Content-Type: application/json
//Request Body:	empty
//Response
//Status Code: 	200 Ok	Body: 	[ { "Username": "doncho@minkov.it",
//     "Rank": 315 },
//  {  "Username": "doncho@minkov.com",
//     "Rank": 115 },
//  {  "Username": "dodo@minkov.it", 
//      "Rank": 30 } ]

        public IHttpActionResult Get()
        {
            return
                this.Ok(
                    this.Data.Users.All()
                        .Select(u => new { UserName = u.UserName, Rank = u.Wons * 100 + u.Loses * 15 })
                        .OrderByDescending(u => u.Rank)
                        .Take(10));
        }
    }
}

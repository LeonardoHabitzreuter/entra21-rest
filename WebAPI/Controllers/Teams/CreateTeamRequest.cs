using System.Collections.Generic;

namespace WebAPI.Controllers.Teams
{
    public class CreateTeamRequest
    {
        public string Name { get; set; }
        public IList<string> Players { get; set; }
    }
}
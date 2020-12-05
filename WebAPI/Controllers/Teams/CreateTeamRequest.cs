using System.Collections.Generic;

namespace WebAPI.Controllers.Teams
{
    public class CreatePlayerRequest
    {
        public string Name { get; set; }
    }

    public class CreateTeamRequest
    {
        public string Name { get; set; }
        public IList<CreatePlayerRequest> Players { get; set; }
    }
}
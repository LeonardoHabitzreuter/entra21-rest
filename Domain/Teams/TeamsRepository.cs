using Domain.Infra;

namespace Domain.Teams
{
    class TeamsRepository
    {
        public void Add(Team team)
        {
            using (var db = new BrasileiraoContext())
            {
                db.Teams.Add(team);
                db.SaveChanges();
            }
        }
    }
}

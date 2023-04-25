using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fustalesco.Infrastructure.Entities
{
    public class Team
    {
        public long Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public int MatchesPlayed { get; set; }
        public int Won { get; set; }
        public int Draw { get; set; }
        public int Lost { get; set; }
        public int NumberOfPlayers { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }
        public int PenaltyPoints { get; set; }
        public int Points => (Won * 3) + Draw - PenaltyPoints;

        public long TournamentId { get; set; }


        public ICollection<Player> Players { get; set; }

        public Tournament Tournament { get; set; }

    }
}

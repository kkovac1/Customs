using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fustalesco.Infrastructure.Entities
{
    public class Match
    {
        public long Id { get; set; }

        public long TournamentId { get; set; }

        public long TeamOneId { get; set; }
        public Team TeamOne { get; set; }

        public long TeamTwoId { get; set; }
        public Team TeamTwo { get; set; }

        public long? WinningTeamId { get; set; }
        public Team WinningTeam { get; set; }

        public int Round { get; set; }

        public DateTime ScheduledAt { get; set; }

        public virtual Tournament Tournament { get; set; }
        public Result Result { get; set; }

    }
}

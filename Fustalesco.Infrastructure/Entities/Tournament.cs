using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fustalesco.Infrastructure.Entities
{
    public class Tournament
    {
        public long Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public int Rounds { get; set; }


        public ICollection<Match> Matches { get; set; }
        public ICollection<Team> Teams { get; set; }

    }
}

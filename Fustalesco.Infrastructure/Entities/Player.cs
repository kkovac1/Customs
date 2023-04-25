using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fustalesco.Infrastructure.Entities
{
    public class Player
    {
        public long Id { get; set; }
        public long TeamId { get; set; }

        [MaxLength(50)]
        public string Firstname { get; set; }

        [MaxLength(50)]
        public string Lastname { get; set; }
        public int Goals { get; set; }
        public int MatchesPlayed { get; set; }
        public Team Team { get; set; }
    }
}

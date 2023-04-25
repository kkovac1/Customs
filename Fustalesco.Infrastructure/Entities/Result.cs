using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fustalesco.Infrastructure.Entities
{
    public class Result
    {
        public long Id { get; set; }
        public int TeamOneScore { get; set; }
        public int TeamTwoScore{ get; set; }
        public long MatchId { get; set; }

        public Match Match { get; set; }
    }
}

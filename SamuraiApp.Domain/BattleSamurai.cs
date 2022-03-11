using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Domain
{
    public class BattleSamurai
    {
        public Guid SamuraiId { get; set; }
        public Guid BattleId { get; set; }
        public DateTime DateJoined { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveEchoes.Mechanics.Stats.StatCollection
{
    public interface IStatCollection
    {
        public IEnumerable<IStat> Stats { get; }
    }
}

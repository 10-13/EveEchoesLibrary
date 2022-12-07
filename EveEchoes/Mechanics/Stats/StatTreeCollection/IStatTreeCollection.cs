using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EveEchoes.Mechanics.Stats.StatCollection;

namespace EveEchoes.Mechanics.Stats.StatTreeCollection
{
    internal interface IStatTreeCollection : IStatCollection
    {
        IEnumerable<IStatCollection> Childs { get; }
    }
}

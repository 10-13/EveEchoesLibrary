using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EveEchoes.Mechanics.Stats.StatCollection
{
    public abstract class StatCollection : IStatCollection
    {
        [XmlIgnore]
        IEnumerable<IStat> IStatCollection.Stats => Stats;


        public List<IStat> Stats { get; set; }
    }
}

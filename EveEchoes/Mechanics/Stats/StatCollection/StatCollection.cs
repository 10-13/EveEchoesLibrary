using System;
using System.Collections;
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

        private class ListlikeStatCollection : StatCollection, IEnumerable<IStat>
        {
            public ListlikeStatCollection(IEnumerable<IStat> stats)
            {
                this.Stats = new List<IStat>(stats);
            }

            public IEnumerator<IStat> GetEnumerator()
            {
                return Stats.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return Stats.GetEnumerator();
            }
        }

        public static IStatCollection GetDefaultStatCollection(params IStat[] stats) 
        {
            return new ListlikeStatCollection(stats);
        }
    }
}
